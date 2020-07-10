using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gluon
{
    public enum CodeLineStyle
    {
        Standard,
        SingleLine,
        Literal
    }

    public enum CodeListStyle
    {
        SingleLine,
        MultiLine,
        Compact
    }

    public enum Scope
    {
        Public,
        Protected,
        Internal,
        Private
    }

    public abstract class PascalRender
    {
        public AST.Namespace WorkingNamespace { get; set; }
        public bool WorkingABINamespace { get; set; }
        public ApiStrata Strata { get; set; }
        public HashSet<AST.Namespace> UsingNamespaces { get; private set; } = new HashSet<AST.Namespace>();
        public HashSet<AST.Namespace> UsingABINamespaces { get; private set; } = new HashSet<AST.Namespace>();
        protected abstract string ScopeOperator { get; }

        public virtual bool Use(AST.Namespace ns, bool abi)
        {
            if (!abi && !UsingNamespaces.Contains(ns))
                UsingNamespaces.Add(ns);
            else if (abi && !UsingABINamespaces.Contains(ns))
                UsingABINamespaces.Add(ns);
            else
                return false;
            return true;
        }

        public abstract string TypeName(AST.IVariable v, bool? abi = null);
        public abstract string TypeName(AST.Type v, bool? abi = null);
        public abstract void Namespace(AST.Namespace ns, bool abi, Action content);
        public abstract void ParameterType(AST.IVariable arg, bool? abi = null);

        public PascalRender()
        {
            IndentStyle = "    ";
            GenerateIndentLine();
            _atLineStart = true;
            _atVirtualLineStart = true;
            WorkingNamespace = BasicTypes.GlobalNamespace;
        }


        public CodeListStyle ListStyle { get; private set; } = CodeListStyle.SingleLine;

        #region LineStyle

        public CodeLineStyle LineStyle
        {
            get { return _LineStyle; }
            set
            {
                var old = _LineStyle;

                if (value == CodeLineStyle.SingleLine && _regionState.InsertSpacer)
                    Line();

                if (_LineStyle == value) return;
                _LineStyle = value;

                if (old == CodeLineStyle.SingleLine && _atVirtualLineStart)
                {
                    var oldSpacer = _regionState.InsertSpacer;
                    _regionState.InsertSpacer = false;
                    Line();
                    _regionState.InsertSpacer = oldSpacer;
                }
            }
        }
        private CodeLineStyle _LineStyle;

        #endregion

        #region IndentStyle

        public string IndentStyle
        {
            get { return _IndentStyle; }
            set
            {
                _IndentStyle = value;
                GenerateIndentLine();
            }
        }
        private string _IndentStyle;

        #endregion

        #region Indent

        public int Indent
        {
            get { return _Indent; }
            set
            {
                _Indent = value;
                GenerateIndentLine();
            }
        }
        private int _Indent;

        #endregion

        public int CurrentListSize { get { return _currentListSize; } }

        public int Size { get { return _code.Length; } }

        public virtual void Clear()
        {
            _code.Clear();
            _commaListGroups.Clear();
            IndentStyle = "    ";
            GenerateIndentLine();
            _atLineStart = true;
            _atVirtualLineStart = true;
            _currentListSize = 0;
        }

        private void CommitListSeparator()
        {
            if (_atListItemStart)
            {
                _atListItemStart = false;

                switch (ListStyle)
                {
                    case CodeListStyle.SingleLine:
                        _code.Append(", ");
                        break;
                    case CodeListStyle.MultiLine:
                        Line(",");
                        break;
                    case CodeListStyle.Compact:
                        Code(",");
                        break;
                }
            }
        }

        public void Code(string code)
        {
            if (string.IsNullOrEmpty(code)) return;

            CommitListSeparator();

            var regex = _atVirtualLineStart ? _NewLineIndentRegex : _IndentRegex;

            switch (LineStyle)
            {
                case CodeLineStyle.Standard:
                    {
                        code = regex.Replace(code, m =>
                        {
                            var indent = m.Groups["indent"];

                            if (!indent.Success)
                                return m.Value;

                            var ret = "";
                            var index = indent.Index - m.Index;

                            if (index != 0)
                                ret = m.Value.Substring(0, index);

                            for(int i = 0;i < indent.Length;i += 4)
                                ret += IndentStyle;

                            if (index + indent.Length < m.Length)
                                ret += m.Value.Substring(index + indent.Length);

                            return ret;
                        });

                        if (_regionState.InsertSpacer)
                            Line();
                        if (_atLineStart)
                            _code.Append(_indentLine);

                        if (code.EndsWith("\n"))
                        {
                            code = code.Substring(0, code.Length - 1);
                            code = code.Replace("\n", _indentReplacer);
                            code += "\n";
                        }
                        else
                            code = code.Replace("\n", _indentReplacer);

                        _atVirtualLineStart = _atLineStart = (code.Last() == '\n');

                        _code.Append(code);
                    }
                    break;
                case CodeLineStyle.SingleLine:
                    {
                        code = regex.Replace(code, m =>
                        {
                            var indent = m.Groups["indent"];

                            if (!indent.Success)
                                return m.Value;

                            var ret = "";
                            var index = indent.Index - m.Index;

                            if (index != 0)
                                ret = m.Value.Substring(0, index);

                            if (index + indent.Length < m.Length)
                                ret += m.Value.Substring(index + indent.Length);

                            return ret;
                        });

                        if (_regionState.InsertSpacer)
                            Line();
                        if (_atLineStart)
                            _code.Append(_indentLine);

                        _atLineStart = false;
                        _atVirtualLineStart = code != "" && (code.Last() == '\n');
                        _code.Append(code.Replace("\r\n", " ").Replace('\n', ' '));
                    }
                    break;
                default:
                    _code.Append(code);
                    break;
            }

            _regionState.AtStart = false;
        }

        public void Code(string fmt, params object[] args)
        {
            Code(string.Format(fmt, args));
        }

        public void Line()
        {
            CommitListSeparator();

            if (LineStyle == CodeLineStyle.SingleLine)
            {
                _code.Append(' ');

                if (_regionState.InsertSpacer && !_atLineStart)
                {
                    _code.AppendLine();
                    _atLineStart = true;
                    _regionState.InsertSpacer = false;
                }
            }
            else
            {
                _code.AppendLine();

                if (_regionState.InsertSpacer && !_atLineStart)
                    _code.AppendLine();

                _atLineStart = true;
                _regionState.InsertSpacer = false;
            }

            _atVirtualLineStart = true;
        }

        public void Line(string line)
        {
            Code(line);
            Line();
        }

        public void Line(string fmt, params object[] args)
        {
            Code(fmt, args);
            Line();
        }

        public void BeginRegion()
        {
            if (!_atLineStart)
                Line();

            _regionStateStack.Push(_regionState);
            _regionState = new RegionState() { AtStart = true };
        }

        public void Spacer()
        {
            if (!_atLineStart)
                Line();

            _regionState.InsertSpacer = !_regionState.AtStart;
        }

        public void EndRegion()
        {
            if (!_atVirtualLineStart)
                Line();

            _regionState = _regionStateStack.Pop();
        }

        public void NextListItem()
        {
            _atListItemStart = true;
            _currentListSize++;
        }

        public void ListItem(string item)
        {
            Code(item);
            NextListItem();
        }

        public void ListItem(string fmt, params object[] args)
        {
            ListItem(string.Format(fmt, args));
        }

        public void LineComment(string comment)
        {
            Line("// " + comment);
        }

        public void LineComment(string fmt, params object[] args)
        {
            Line("// " + fmt, args);
        }

        public void BeginBlockComment()
        {
            Code("/* ");
            _indentLine += " * ";
            _indentReplacer = "\n" + _indentLine;
        }

        public void EndBlockComment()
        {
            GenerateIndentLine();
            Line(" */");
        }

        public void BeginXmlDoc()
        {
            if (!_atLineStart)
                Line();

            _indentLine += "/// ";
            _indentReplacer = "\n" + _indentLine;
        }

        public void EndXmlDoc()
        {
            GenerateIndentLine();
        }

        public void BeginList(CodeListStyle style = CodeListStyle.SingleLine)
        {
            _commaListGroups.Push(_currentListSize);
            _listStyleStack.Push(ListStyle);

            ListStyle = style;
            _currentListSize = 0;
        }

        public void EndList()
        {
            _currentListSize = _commaListGroups.Pop();
            ListStyle = _listStyleStack.Pop();
            _atListItemStart = false;
        }

        public void Block(Action body, string postScript = "")
        {
            Line("{");
            Indent++;
            BeginRegion();
            body();
            EndRegion();
            Indent--;
            Line("}}{0}", postScript);
            Spacer();
        }
        
        public override string ToString()
        {
            return _code.ToString();
        }

        public void Write(string filePath)
        {
            U.WriteFileIfModified(filePath, ToString());
        }

        public void DeclParameter(AST.IVariable arg, bool declareDefaultValue = false)
        {
            bool hasDefault = false;
            object defaultValue = null;

            var p = arg as AST.Parameter;
            if (p != null && declareDefaultValue)
            {
                hasDefault = p.HasDefaultValue;
                defaultValue = p.DefaultValue;
            }

            ParameterType(arg);
            Code(" " + arg.Name);

            if (hasDefault)
                Code(" = {0}", ToLiteral(defaultValue, arg.Type));
        }

        public virtual string ToLiteral(object lit, AST.Type type = null)
        {
            return lit.ToString();
        }

        public void WriteParameters(params object[] args)
        {
            WriteParameters(false, args);
        }

        public void WriteParameters(bool defaultValues, params object[] args)
        {
            BeginList();

            Action<object> handleObject = null;
            handleObject = o =>
            {
                var str = o as string;
                var ivar = o as AST.IVariable;
                var coll = o as IEnumerable;

                if (str != null)
                    ListItem(str);
                if (ivar != null)
                {
                    DeclParameter(ivar, defaultValues);
                    NextListItem();
                }
                if (coll != null)
                    foreach (var item in coll)
                        handleObject(item);
            };

            foreach (var arg in args)
                handleObject(arg);

            EndList();
        }

        public void Directive(string line)
        {
            var tmp = Indent;
            Indent = 0;
            Line(line);
            Indent = tmp;
        }

        public void Directive(string fmt, params object[] args)
        {
            var tmp = Indent;
            Indent = 0;
            Line(fmt, args);
            Indent = tmp;
        }

        #region Internal

        protected string ScopeTo(AST.Namespace ns)
        {
            var usingParent = ns;
            string ret = "";
            while (usingParent != WorkingNamespace && !UsingNamespaces.Contains(usingParent) && !usingParent.IsGlobal)
            {
                ret = usingParent.Name + ScopeOperator + ret;
                usingParent = usingParent.Parent;
            }
            return ret;
        }

        private void GenerateIndentLine()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Indent; i++)
                sb.Append(IndentStyle);
            _indentLine = sb.ToString();

            sb.Clear();
            sb.Append('\n');
            sb.Append(_indentLine);
            _indentReplacer = sb.ToString();

            _indentChars = IndentStyle.ToCharArray();
        }

        private struct RegionState
        {
            public bool AtStart;
            public bool InsertSpacer;
        }

        protected readonly StringBuilder _code = new StringBuilder();
        private bool _atLineStart;
        private bool _atVirtualLineStart;
        private bool _atListItemStart;
        private RegionState _regionState = new RegionState() { AtStart = true };
        private string _indentLine;
        private string _indentReplacer;
        private char[] _indentChars;
        private int _currentListSize;
        private Stack<int> _commaListGroups = new Stack<int>();
        private Stack<RegionState> _regionStateStack = new Stack<RegionState>();
        private Stack<CodeListStyle> _listStyleStack = new Stack<CodeListStyle>();
        private static Regex _NewLineIndentRegex = new Regex(@"(^(?<indent>(    )+))|(\n(?<indent>(    )+))", RegexOptions.Compiled);
        private static Regex _IndentRegex = new Regex(@"\n(?<indent>(    )+)", RegexOptions.Compiled);

        #endregion
    }
}
