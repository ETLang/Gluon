using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gluon.AST
{
    public abstract class Type : Node, IHasAttributes
    {
        private static readonly Guid BaseId = new Guid("5329E9D6-84E5-4FDE-92EB-9D58728FEC74");
        private static readonly Guid PrivateBaseId = new Guid("74A15BC8-8EAA-4AE6-A938-434052556BA5");

        public bool IsPureReference { get; set; }
        public bool IsAttribute { get; set; }
        public Assembly Assembly { get; set; }
        public TypeOrigin Origin { get; set; }
        public string CppHeader { get; set; }
        public string CppLib { get; set; }
        public Access Access { get; set; }

        public bool IsVoid { get { return ConstructType == Construct.Void; } }
        public bool IsPrimitive { get { return ConstructType == Construct.Primitive; } }
        public bool IsString { get { return ConstructType == Construct.String; } }
        public bool IsEnum { get { return ConstructType == Construct.Enum; } }
        public bool IsStruct { get { return ConstructType == Construct.Struct; } }
        public bool IsObject { get { return ConstructType == Construct.Object; } }
        public bool IsDelegate { get { return ConstructType == Construct.Delegate; } }
        public bool IsTask { get { return ConstructType == Construct.Task; } }
        public bool IsBool { get { return Namespace == BasicTypes.SystemNamespace && Name == "bool"; } }


        #region Namespace

        public Namespace Namespace
        {
            get { return _Namespace; }
            set
            {
                if (_Namespace == value) return;
                _Namespace = value;
                _ShortId = null;
            }
        }
        private Namespace _Namespace;

        #endregion

        #region ShortId

        public string ShortId
        {
            get
            {
                var uniqueName = UniqueName;
                if (_knownUniqueName != uniqueName || _ShortId == null)
                {
                    _knownUniqueName = uniqueName;
                    var hash = uniqueName.GetHashCode();
                    while (_TakenShortIDs.Contains(hash)) hash++;
                    _TakenShortIDs.Add(hash);
                    _ShortId =  "_" + hash.ToString("X");
                }
                return _ShortId;
            }
        }
        public string _ShortId;

        #endregion

        public List<Attribute> Attributes { get; private set; } = new List<Attribute>();

        public Guid Id { get { return U.HashNameToGuid(BaseId, UniqueName); } }
        public Guid PrivateId { get { return U.HashNameToGuid(PrivateBaseId, UniqueName); } }

        public string Summary
        {
            get { return XmlDoc?["summary"]?.InnerText.Trim(); }
        }

        public string Remarks
        {
            get { return XmlDoc?["remarks"]?.InnerText.Trim(); }
        }

        public override IEnumerable<Node> Declarations
        {
            get
            {
                return Many(
                    base.Declarations,
                    With<Node>(Assembly, Namespace),
                    Attributes.SelectMany(attr => attr.Declarations));
            }
        }

        public override string UniqueName
        {
            get
            {
                return this.FullName(".");
            }
        }

        protected Type(Construct construct) : base(construct) { Debug.Assert(construct.HasFlag(Construct.Type)); }

        private string _knownUniqueName;
        private static HashSet<int> _TakenShortIDs = new HashSet<int>();
    }
}
