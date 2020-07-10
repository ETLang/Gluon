using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon
{
    public class CheapoParser<TT>
    {
        public IReadOnlyDictionary<TT,string> LexTable { get; private set; }
        public IReadOnlyDictionary<TT, string> ParseTable { get; private set; }
        public IReadOnlyDictionary<string,TT> KeywordTable { get; private set; }
        public TT BaseKeywordType { get; private set; }
        public TT EmptyType { get; private set; }
        public IReadOnlyList<TT> InsignificantTypes { get; private set; }

        public CheapoParser(Dictionary<TT,string> lexTable, Dictionary<TT,string> parseTable, Dictionary<string,TT> keywordTable, TT baseKeywordType, TT emptyType, TT[] insignificantTypes)
        {
            _lexTable = CopyDict(lexTable);
            _parseTable = CopyDict(parseTable);
            _keywordTable = CopyDict(keywordTable);
            _insignificantTypes = (TT[])insignificantTypes.Clone();

            LexTable = _lexTable;
            ParseTable = _parseTable;
            KeywordTable = _keywordTable;
            InsignificantTypes = _insignificantTypes;
            BaseKeywordType = baseKeywordType;
            EmptyType = emptyType;
        }
        
        private Dictionary<A,B> CopyDict<A,B>(Dictionary<A,B> d)
        {
            var ret = new Dictionary<A, B>();
            foreach(var kvp in d)
                ret.Add(kvp.Key, kvp.Value);

            return ret;
        }

        Dictionary<TT, string> _lexTable;
        Dictionary<TT, string> _parseTable;
        Dictionary<string, TT> _keywordTable;
        TT[] _insignificantTypes;
    }

    public class Token<TT>
    {
        public readonly TT Type;
        public readonly string Value;
        public readonly bool IsSignificant;

        public List<Token<TT>> Subs { get; private set; }

        public IEnumerable<Token<TT>> Lexical
        {
            get
            {
                if (Subs.Count == 0)
                    yield return this;
                else
                    foreach (var token in Subs)
                        foreach (var lt in token.Lexical)
                            yield return lt;
            }
        }

        public IEnumerable<Token<TT>> Significant
        {
            get
            {
                foreach (var tok in Subs)
                    if (tok.IsSignificant)
                        yield return tok;
            }
        }

        public IEnumerable<Token<TT>> SignificantLexical
        {
            get
            {
                foreach (var tok in Lexical)
                    if (tok.IsSignificant)
                        yield return tok;
            }
        }

        public Token(TT type) : this(type, null) { }

        public Token(TT type, string value, bool significant = true)
        {
            Type = type;
            Value = value;
            IsSignificant = significant;
            Subs = new List<Token<TT>>();
        }

        public override string ToString()
        {
            if (Value != null)
                return Value;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var t in Subs)
                    sb.Append(t.ToString());
                return sb.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as Token<TT>;

            if (!rhs.Type.Equals(Type))
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

                if (!e1.Current.Type.Equals(e2.Current.Type) || e1.Current.Value != e2.Current.Value)
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
