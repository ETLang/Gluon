using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gluon
{
    public enum TkType
    {
        Space = ' ',
        String = 'S',
        Number = 'N',
        Identifier = 'I',
        LParen = '(',
        RParen = ')',
        LBrace = '{',
        RBrace = '}',
        LAngle = '<',
        RAngle = '>',
        Comma = ',',
        EndStatement = ';',
        Namescope = ':',
        Hash = '#',
        QualifiedId = 'Q',
        Block = '8',
        ParenBlock = '0',
        TemplateBlock = 'T',
        FunctionSig = 'X',
        FunctionDef = 'F',
        BaseLink = '.',
        BaseCall = 'B',
        KwInclude = 'i',
        KwPragma = 'p',
        KwRegion = 'r',
        KwEndRegion = 'e',
        KwClass = 'c',
        KwComid = 'o',
        KwDeclspec = 'd',
        KwIf = 'f',
        KwWhile = 'w',
        KwFor = 'r',
        Directive = '$',
        Region = 'R',
        Declspec = 'D',
        ClassDef = 'C',
        PtrOperator = '*',
        RefOperator = '&',
        Special = '!'
    }

    public class CppParser
    {
        public string OriginalCode { get; private set; }

        public List<Token> Contents { get; private set; }

        public IEnumerable<Token> Tree
        {
            get
            {
                foreach (var token in Contents)
                    foreach (var sub in token.Tree)
                        yield return sub;
            }
        }

        public IEnumerable<Token> Lexical
        {
            get
            {
                foreach (var token in Contents)
                    foreach (var lt in token.Lexical)
                        yield return lt;
            }
        }

        public IEnumerable<Token> Significant
        {
            get
            {
                foreach (var tok in Contents)
                    if (tok.Type != TkType.Space)
                        yield return tok;
            }
        }

        public IEnumerable<Token> SignificantLexical
        {
            get
            {
                foreach (var tok in Lexical)
                    if (tok.Type != TkType.Space)
                        yield return tok;
            }
        }

        public CppParser(string code)
        {
            OriginalCode = code;
            Contents = new List<Token>();
            Lex();
            Parse();
        }

        static CppParser()
        {
            var rules = new StringBuilder();
            string chain = "";
            foreach (var kvp in LexTable)
            {
                rules.Append(chain);
                rules.AppendFormat("(?<{0}>{1})", kvp.Key.ToString(), kvp.Value);
                chain = "|";
            }
            Lexer = new Regex(rules.ToString(), RegexOptions.Multiline | RegexOptions.Compiled);

            rules.Clear();
            chain = "";
            foreach (var kvp in ParseTable)
            {
                rules.Append(chain);
                rules.AppendFormat("(?<{0}>{1})", kvp.Key.ToString(), kvp.Value);
                chain = "|";
            }
            Parser = new Regex(rules.ToString(), RegexOptions.Multiline | RegexOptions.Compiled);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var token in Contents)
                sb.Append(token.ToString());
            return sb.ToString();
        }

        private static Dictionary<TkType, string> LexTable = new Dictionary<TkType, string>
        {
            { TkType.Directive,     @"\#(?!pragma region|pragma endregion)(.*\\(\r)?\n)*.*" },
            { TkType.Space,         @"\s+|\/\/.*|\/\*(\*(?!\/)|[^*])*\*\/" },
            { TkType.String,        @"\""(\\(\r)?\n|[^\""])*\""" },
            { TkType.Number,        @"(0x[0-9a-fA-F]+\.?|0x[0-9a-fA-F]*\.[0-9a-fA-F]+|\d+\.?|\d*\.\d+)([eEpP][+-]?[0-9a-fA-F]+)?([lLfFuU]|ul|UL|ull|ULL)?"},
            { TkType.Identifier,    @"[a-zA-Z_][a-zA-Z0-9_]*" },
            { TkType.LParen,        @"\(" },
            { TkType.RParen,        @"\)" },
            { TkType.LBrace,        @"\{" },
            { TkType.RBrace,        @"\}" },
            { TkType.LAngle,        @"<" },
            { TkType.RAngle,        @">" },
            { TkType.Comma,         @"," },
            { TkType.EndStatement,  @";" },
            { TkType.Namescope,     @"::" },
            { TkType.BaseLink,      @":"  },
            { TkType.Hash,          @"#" },
            { TkType.PtrOperator,   @"\*" },
            { TkType.RefOperator,   @"\&" }
            /* TkType.Special matches anything else */
        };

        private static Dictionary<TkType, string> ParseTable = new Dictionary<TkType, string>
        {
            { TkType.QualifiedId,   @"I|(?![^QI]):Q|QT|Q:Q" },
            { TkType.Block,         @"{[^{}po]*}" },
            //{ TkType.ParenBlock,    @"\([^\(\)]*\)" },
            { TkType.ParenBlock,    @"\([IQ&\*,]*\)" },
            { TkType.TemplateBlock, @"<[IQX,]*>" },
            //{ TkType.TemplateBlock, @"<[^<>;{}]*>" },
          //  { TkType.BaseCall,      @"\.Q0" },
            { TkType.FunctionSig,   @"Q\**Q0Q*|(?<!,|\.)Q0Q*" },
            { TkType.FunctionDef,   @"X(\.Q(0|\((?:[^()]|(?<Open>[(])|(?<-Open>[)]))*(?(Open)(?!))\))(,Q(0|\((?:[^()]|(?<Open>[(])|(?<-Open>[)]))*(?(Open)(?!))\)))*)?8" },
            //{ TkType.FunctionDef,   @"X(\.Q(0|\([^\(\)]*\))(,Q0)*)?8" },
            { TkType.Region,        @"#pr(#p[^e]|#[^p]|[^#])*#pe" },
            { TkType.Declspec,      @"d0" },
            { TkType.ClassDef,      @"cD*o0D*Q\.QQ(?=[^T])" }
        };

        private static Dictionary<string, TkType> KeywordTable = new Dictionary<string, TkType>
        {
            { "region", TkType.KwRegion },
            { "endregion", TkType.KwEndRegion },
            { "class", TkType.KwClass },
            { "comid", TkType.KwComid },
            { "__declspec", TkType.KwDeclspec },
            { "if", TkType.KwIf },
            { "while", TkType.KwWhile },
            { "for", TkType.KwFor },
            { "pragma", TkType.KwPragma },
            //{ "include", TkType.KwInclude },
        };

        private const TkType BaseKeywordType = TkType.Identifier;

        private void Lex()
        {
            int cursor = 0;
            var names = Enum.GetNames(typeof(TkType)).Intersect(Lexer.GetGroupNames()).ToArray();

            while (cursor != OriginalCode.Length)
            {
                var m = Lexer.Match(OriginalCode, cursor);

                if (!m.Success)
                {
                    Contents.Add(new Token(OriginalCode.Substring(cursor)));
                    return;
                }
                else
                {
                    if (m.Index != cursor)
                        Contents.Add(new Token(OriginalCode.Substring(cursor, m.Index - cursor)));

                    cursor = m.Index + m.Length;

                    foreach(var name in names)
                    {
                        var g = m.Groups[name];

                        if(g.Success)
                        {
                            var tokenType = (TkType)Enum.Parse(typeof(TkType), name);

                            if (tokenType == BaseKeywordType)
                            {
                                foreach (var kvp in KeywordTable)
                                {
                                    if (g.Value == kvp.Key)
                                    {
                                        tokenType = kvp.Value;
                                        break;
                                    }
                                }
                            }

                            Contents.Add(new Token(tokenType, g.Value));
                            break;
                        }
                    }
                }
            }
        }

        private void Parse()
        {
            var names = Enum.GetNames(typeof(TkType)).Intersect(Parser.GetGroupNames()).ToArray();
            
            bool matched = true;

            while (matched)
            {
                matched = false;

                var sb = new StringBuilder();
                List<int> indices = new List<int>();
                for(int i = 0;i < Contents.Count;i++)
                {
                    var type = Contents[i].Type;

                    if (type != TkType.Space)
                    {
                        sb.Append((char)type);
                        indices.Add(i);
                    }
                }
                indices.Add(Contents.Count);
                var sequence = sb.ToString();

                List<Token> parsed = new List<Token>();

                int cursor = 0;

                if(indices.Count != 0)
                    for (int i = 0; i < indices[0]; i++)
                        parsed.Add(Contents[i]);

                while (cursor != sequence.Length)
                {
                    var m = Parser.Match(sequence, cursor);

                    if (!m.Success)
                    {
                        for (int i = indices[cursor]; i != Contents.Count;i++)
                            parsed.Add(Contents[i]);
                        break;
                    }

                    for (int i = indices[cursor]; i != indices[m.Index]; i++)
                        parsed.Add(Contents[i]);
                    cursor = m.Index;

                    foreach (var name in names)
                    {
                        var g = m.Groups[name];
                        if (g.Success)
                        {
                            matched = true;

                            var tokenType = (TkType)Enum.Parse(typeof(TkType), name);
                            var tok = new Token(tokenType);
                            var end = g.Index + g.Length;
                            int i;
                            for (i = indices[cursor]; i != indices[end - 1] + 1; i++)
                                tok.Subs.Add(Contents[i]);
                            parsed.Add(tok);
                            for (; i != indices[end]; i++)
                                parsed.Add(Contents[i]);
                            cursor = end;
                            break;
                        }
                    }
                }

                Contents = parsed;
            }

            // look for matches
            // For each match, roll matched tokens into a new token. Replace new token in the list.
        }

        private static Regex Lexer;
        private static Regex Parser;
    }

    public class Token
    {
        public readonly TkType Type;
        public string Value { get; set; }
        public bool Exclude { get; set; }

        public List<Token> Subs { get; private set; }

        public IEnumerable<Token> Tree
        {
            get
            {
                yield return this;

                foreach (var sub in Subs.Where(s => !s.Exclude))
                    foreach (var s in sub.Tree)
                        yield return s;
            }
        }

        public IEnumerable<Token> Lexical
        {
            get
            {
                if (Subs.Count == 0)
                    yield return this;
                else
                    foreach (var token in Subs.Where(s => !s.Exclude))
                        foreach (var lt in token.Lexical)
                            yield return lt;
            }
        }

        public IEnumerable<Token> Significant
        {
            get
            {
                foreach (var tok in Subs)
                    if (tok.Type != TkType.Space && !tok.Exclude)
                        yield return tok;
            }
        }

        public IEnumerable<Token> SignificantLexical
        {
            get
            {
                foreach (var tok in Lexical)
                    if (tok.Type != TkType.Space && !tok.Exclude)
                        yield return tok;
            }
        }

        public Token() : this(TkType.Special, null) { }

        public Token(string rawText) : this(TkType.Special, rawText) { }

        public Token(TkType type) : this(type, null) { }

        public Token(TkType type, string value)
        {
            Type = type;
            Value = value;
            Subs = new List<Token>();
        }

        public override string ToString()
        {
            if (Value != null)
                return Value;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var t in Subs)
                {
                    if(!t.Exclude)
                        sb.Append(t.ToString());
                }
                return sb.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as Token;

            if (rhs.Type != Type)
                return false;

            var e1 = SignificantLexical.GetEnumerator();
            var e2 = rhs.SignificantLexical.GetEnumerator();
            bool n1, n2;
            while (true)
            {
                n1 = e1.MoveNext();
                n2 = e2.MoveNext();

                if (!n1)
                    break;

                if (e1.Current.Type != e2.Current.Type || e1.Current.Value != e2.Current.Value)
                    return false;
            }

            return n1 == n2;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
