using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Gluon.AST
{
    /// <summary>
    /// Builder is responsible for constructing a Gluon definition from a reflected assembly.
    /// </summary>
    public class Builder
    {
        public Definition Product { get; private set; }

        public Builder(Definition product = null)
        {
            if (product == null)
                Product = new Definition();
            else
                Product = product;

            foreach (var ns in Product.DependentNamespaces)
                _namespaceMap[ns.FullName(".")] = ns;
        }

        public void BuildFromAssembly(System.Reflection.Assembly assembly)
        {
            _primaryAssembly = assembly;

            _assemblyMap[assembly] = Product.Assembly;

            Product.Assembly.Name = Product.Name = assembly.GetName().Name;
            Product.Assembly.IsGluonDefinition = assembly.GetCustomAttribute<GluonLibraryDefinitionAttribute>() != null;
            foreach (var attr in assembly.GetCustomAttributesData())
                Product.Assembly.Attributes.Add(Resolve(attr));

            foreach (var type in assembly.GetTypes())
                Resolve(type);

            foreach(var map in assembly.GetCustomAttributes<MappedTypeAttribute>())
            {
                var targets = map.Target.Split(new char[] { ';', ',' }, StringSplitOptions.None);

                foreach (var target in targets)
                {
                    if (map.ManagedType != null)
                        Product.SubstituteTypes.Add(new SubstituteType()
                        {
                            TargetID = target,
                            OriginalType = Resolve(map.OriginType),
                            TargetType = Resolve(map.ManagedType)
                        });
                    else
                        Product.NativeMappedTypes.Add(new NativeMappedType()
                        {
                            TargetID = target,
                            ManagedType = Resolve(map.OriginType),
                            NativeType = map.NativeType,
                            NativeHeader = map.NativeHeader,
                            NativeLibrary = map.NativeLibrary
                        });
                }
            }

            foreach(var map in assembly.GetCustomAttributes<MappedNamespaceAttribute>())
            {
                var targets = map.Target.Split(new char[] { ';', ',' }, StringSplitOptions.None);

                foreach (var target in targets)
                Product.SubstituteNamespaces.Add(new SubstituteNamespace
                {
                    TargetID = target,
                    FromNamespace = Resolve(map.FromNamespace),
                    ToNamespace = Resolve(map.ToNamespace)
                });
            }
        }

        public Assembly Resolve(System.Reflection.Assembly assembly)
        {
            if (assembly == null)
                return null;

            Assembly ret;
            if (_assemblyMap.TryGetValue(assembly, out ret))
                return ret;

            ret = new Assembly();
            _assemblyMap[assembly] = ret;
            ret.Name = assembly.GetName().Name;
            Product.DependentAssemblies.Add(ret);

            ret.IsGluonDefinition = assembly.GetCustomAttribute<GluonLibraryDefinitionAttribute>() != null;
            foreach (var attr in assembly.GetCustomAttributesData())
                ret.Attributes.Add(Resolve(attr));

            return ret;
        }

        public Type Resolve(System.Type type)
        {
            if (type == null)
                return null;

            if (type.IsByRef)
                return Resolve(type.GetElementType());
            if (type.IsArray)
                return Resolve(type.GetElementType());

            Type ret;
            if (_typeMap.TryGetValue(type, out ret))
                return ret;

            ret = BasicTypes.Of(type);
            if(ret != null)
            {
                _typeMap[type] = ret;
                return ret;
            }

            switch (ConstructOf(type))
            {
                case Construct.Void:
                    ret = new Void();
                    break;
                case Construct.Primitive:
                    ret = new Primitive();
                    break;
                case Construct.Enum:
                    ret = new Enum();
                    break;
                case Construct.String:
                    ret = new String();
                    break;
                case Construct.Delegate:
                    ret = new Delegate();
                    break;
                case Construct.Task:
                    ret = new Task();
                    break;
                case Construct.Struct:
                    ret = new Struct();
                    break;
                case Construct.Object:
                    ret = new Object();
                    break;
                default:
                    Debug.Assert(false);
                    return null;
            }

            _typeMap[type] = ret;
            Product.AllTypes.Add(ret);
            ret.Name = type.Name;
            ret.Namespace = Resolve(type.Namespace);
            ret.Assembly = Resolve(type.Assembly);
            ret.XmlDoc = XmlDocReader.XMLFromType(type);
            ret.IsAttribute = typeof(System.Attribute).IsAssignableFrom(type);

            var nativeAttr = type.GetCustomAttribute<NativeAttribute>();


            if (ret.IsDelegate && ((AST.Delegate)ret).IsGeneric || ret.IsTask)
            {
                ret.Origin = TypeOrigin.Mapped;
            }
            else if (!ret.Assembly.IsGluonDefinition)
            {
                if (ret.ConstructType == Construct.Object)
                    ret.IsPureReference = true;

                ret.Origin = TypeOrigin.Managed;
            }
            else if (nativeAttr == null)
                ret.Origin = TypeOrigin.Gluon;
            else
            {
                if (ret.ConstructType == Construct.Object)
                    ret.IsPureReference = true;

                ret.Origin = TypeOrigin.Native;

                ret.CppHeader = nativeAttr.Header;
                ret.CppLib = nativeAttr.StaticLibrary;
            }

            foreach (var attr in type.GetCustomAttributesData())
                ret.Attributes.Add(Resolve(attr));

            int isPublic = (type.GetCustomAttribute<PublicAttribute>() != null ? 1 : 0);
            int isProtected = (type.GetCustomAttribute<ProtectedAttribute>() != null ? 1 : 0);
            int isInternal = (type.GetCustomAttribute<InternalAttribute>() != null ? 1 : 0);
            int isPrivate = (type.GetCustomAttribute<PrivateAttribute>() != null ? 1 : 0);

            ret.Access = Access.Public;

            if (isPublic + isProtected + isInternal + isPrivate > 1)
                Errors.Generic(type.FullName + " has multiple, conflicting access attributes");
            else if (isPublic == 1)
                ret.Access = Access.Public;
            else if (isProtected == 1)
                ret.Access = Access.Protected;
            else if (isInternal == 1)
                ret.Access = Access.Internal;
            else if (isPrivate == 1)
                ret.Access = Access.Private;
            
            if(!ret.IsPureReference)
                Merge(ret, type);

            return ret;
        }

        public Attribute Resolve(CustomAttributeData attr)
        {
            if (attr == null)
                return null;

            Attribute ret;
            if (_attributeMap.TryGetValue(attr, out ret))
                return ret;

            ret = new Attribute();
            _attributeMap[attr] = ret;

            ret.Type = Resolve(attr.AttributeType);
            ret.Name = ret.Type.Name;

            foreach (var arg in attr.ConstructorArguments)
                ret.UnnamedParameters.Add(arg.Value);

            foreach (var arg in attr.NamedArguments)
                ret.NamedParameters.Add(new ASTNamedValue(arg.MemberName, arg.TypedValue.Value));

            return ret;
        }

        public Parameter Resolve(ParameterInfo arg)
        {
            if (arg == null)
                return null;

            var ret = new Parameter();

            ret.Name = arg.Name;
            ret.Type = Resolve(arg.ParameterType);
            ret.IsArray = U.Deref(arg.ParameterType).IsArray;

            if (arg.ParameterType != typeof(void))
            {
                ret.HasDefaultValue = arg.HasDefaultValue;
                ret.DefaultValue = arg.DefaultValue;
            }

            if (arg.IsOut)
                ret.Context = VariableContext.Out;
            else if (arg.ParameterType.IsByRef)
                ret.Context = VariableContext.Ref;
            else
                ret.Context = VariableContext.In;

            return ret;
        }

        public Field Resolve(FieldInfo field)
        {
            if (field == null)
                return null;

            var ret = new Field();

            ret.Name = field.Name;
            ret.Type = Resolve(field.FieldType);
            ret.IsArray = U.Deref(field.FieldType).IsArray;
            ret.Access = AccessOf(field);
            ret.XmlDoc = XmlDocReader.XMLFromMember(field);

            return ret;
        }

        public Constructor ResolveAsConstructor(MethodInfo method)
        {
            if (method == null)
                return null;

            Constructor ret;
            if (_constructorMap.TryGetValue(method, out ret))
                return ret;

            ret = new Constructor();
            _constructorMap[method] = ret;

            ret.Name = method.DeclaringType.Name;
            ret.Access = AccessOf(method);
            ret.Nature = MemberNature.Instance;
            ret.XmlDoc = XmlDocReader.XMLFromMember(method);

            foreach (var arg in method.GetParameters())
                ret.Parameters.Add(Resolve(arg));

            foreach (var arg in ret.Parameters)
                arg.XmlDoc = ret.XmlDoc?.ChildNodes.OfType<XmlElement>().FirstOrDefault(xml => xml.LocalName == "typeparam" && xml.Attributes["name"].InnerText == arg.Name);

            return ret;
        }

        public Method Resolve(MethodInfo method)
        {
            if (method == null)
                return null;

            Method ret;
            if (_methodMap.TryGetValue(method, out ret))
                return ret;

            ret = new Method();
            _methodMap[method] = ret;

            ret.Name = method.Name;
            ret.IsConst = (method.GetCustomAttribute<ConstAttribute>() != null);
            ret.Access = AccessOf(method);
            ret.Nature = NatureOf(method);
            ret.XmlDoc = XmlDocReader.XMLFromMember(method);
            ret.Return = Resolve(method.ReturnParameter);
            ret.Return.XmlDoc = ret.XmlDoc?["returns"];

            ret.Return.Context = VariableContext.Return;
            ret.Return.Name = "___ret";

            foreach (var arg in method.GetParameters())
                ret.Parameters.Add(Resolve(arg));

            foreach (var arg in ret.Parameters)
                arg.XmlDoc = ret.XmlDoc?.ChildNodes.OfType<XmlElement>().FirstOrDefault(xml => xml.LocalName == "typeparam" && xml.Attributes["name"].InnerText == arg.Name);

            return ret;
        }

        public Property Resolve(PropertyInfo prop)
        {
            if (prop == null)
                return null;

            if (prop.CanWrite && !prop.CanRead)
            {
                Errors.WriteOnlyProperty(prop);
                return null;
            }

            Property ret;
            if (_propertyMap.TryGetValue(prop, out ret))
                return ret;

            ret = new Property();
            _propertyMap[prop] = ret;

            ret.IsFactory = (prop.GetCustomAttribute<FactoryAttribute>() != null || prop.GetMethod.GetCustomAttribute<FactoryAttribute>() != null);
            ret.ConstGetter = !ret.IsFactory && (prop.GetMethod.GetCustomAttribute<UnconstAttribute>() == null);
            ret.IsBacked = (prop.GetCustomAttribute<BackedAttribute>() != null);
            ret.Name = prop.Name;
            ret.IsArray = U.Deref(prop.PropertyType).IsArray;
            ret.XmlDoc = XmlDocReader.XMLFromMember(prop);
            ret.Type = Resolve(prop.PropertyType);
            ret.Access = AccessOf(prop);
            ret.Nature = NatureOf(prop);
            ret.IsReadOnly = !prop.CanWrite;

            return ret;
        }

        public Event Resolve(EventInfo e)
        {
            if (e == null)
                return null;

            Event ret;
            if (_eventMap.TryGetValue(e, out ret))
                return ret;

            ret = new Event();
            _eventMap[e] = ret;

            ret.Name = e.Name;
            ret.Access = AccessOf(e);
            ret.Nature = NatureOf(e);
            ret.HandlerType = (Delegate)Resolve(e.EventHandlerType);
            ret.XmlDoc = XmlDocReader.XMLFromMember(e);

            var m = e.EventHandlerType.GetMethod("Invoke");

            ret.Return = Resolve(m.ReturnParameter);
            ret.Return.Name = "___ret";
            foreach (var arg in m.GetParameters())
                ret.Parameters.Add(Resolve(arg));

            return ret;
        }

        public Namespace Resolve(string ns)
        {
            if (string.IsNullOrEmpty(ns))
                return BasicTypes.GlobalNamespace;
            if (ns == BasicTypes.SystemNamespace.Name)
                return BasicTypes.SystemNamespace;

            Namespace ret;
            if (_namespaceMap.TryGetValue(ns, out ret))
                return ret;

            ret = new Namespace();
            Product.DependentNamespaces.Add(ret);
            _namespaceMap[ns] = ret;

            var dot = ns.LastIndexOf('.');
            if (dot == -1)
            {
                ret.Name = ns;
                ret.Parent = BasicTypes.GlobalNamespace;
            }
            else
            {
                ret.Name = ns.Substring(dot + 1);
                ret.Parent = Resolve(ns.Substring(0, dot));
            }

            return ret;
        }

        public void Merge(Type ast, System.Type type)
        {
            Debug.Assert(ConstructOf(type) == ast.ConstructType);

            switch(ast.ConstructType)
            {
                case Construct.Enum:
                    Merge((Enum)ast, type);
                    break;
                case Construct.Delegate:
                    Merge((Delegate)ast, type);
                    break;
                case Construct.Struct:
                    Merge((Struct)ast, type);
                    break;
                case Construct.Object:
                    Merge((Object)ast, type);
                    break;
                case Construct.Task:
                    Merge((Task)ast, type);
                    break;
                default:
                    break;
            }
        }

        public void Merge(Enum ast, System.Type type)
        {
            var names = System.Enum.GetNames(type);
            var values = System.Enum.GetValues(type).Cast<int>().ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                XmlElement xml = XmlDocReader.XMLFromMember(type.GetMember(names[i]).FirstOrDefault());
                ast.Entries.Add(new Enum.Entry(names[i], values[i], xml));
            }

            ast.UnderlyingType = Resolve(System.Enum.GetUnderlyingType(type));
        }

        public void Merge(Delegate ast, System.Type type)
        {
            var m = type.GetMethod("Invoke");
            if (m == null) return;

            ast.Return = Resolve(m.ReturnParameter);
            ast.Return.Context = VariableContext.Return;
            ast.Return.Name = "___ret";
            ast.Return.XmlDoc = ast.XmlDoc?["returns"];
            ast.IsGeneric = type.IsGenericType || (type == typeof(Action));

            foreach (var arg in m.GetParameters())
                ast.Parameters.Add(Resolve(arg));

            foreach (var arg in ast.Parameters)
                arg.XmlDoc = ast.XmlDoc?.ChildNodes.OfType<XmlElement>().FirstOrDefault(xml => xml.LocalName == "typeparam" && xml.Attributes["name"].InnerText == arg.Name);
        }

        public void Merge(Struct ast, System.Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToArray();

            foreach (var c in type.GetConstructors())
            {
                var args = c.GetParameters();

                if (args.Length == fields.Length)
                {
                    bool found = true;
                    for(int i = 0;i < args.Length;i++)
                    {
                        if (args[i].ParameterType != fields[i].FieldType)
                            found = false;
                    }
                    if (found)
                        ast.PredefinedFullConstructor = true;
                }
            }

            foreach (var field in fields)
                ast.Fields.Add(Resolve(field));
        }

        public void Merge(Object ast, System.Type type)
        {
            ast.IsAbstract = type.GetCustomAttribute<AbstractAttribute>() != null;
            ast.IsAlreadyGluonGenerated = typeof(GluonObject).IsAssignableFrom(type);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();

            foreach (var m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (m.Name == "Create" && m.ReturnType == type)
                {
                    ast.Constructors.Add(ResolveAsConstructor(m));
                    methods.Remove(m);
                }
            }

            foreach (var p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                ast.Properties.Add(Resolve(p));
                if (p.GetMethod != null)
                    methods.Remove(p.GetMethod);
                if (p.SetMethod != null)
                    methods.Remove(p.SetMethod);
            }

            foreach (var e in type.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                ast.Events.Add(Resolve(e));
                if (e.AddMethod != null)
                    methods.Remove(e.AddMethod);
                if (e.RemoveMethod != null)
                    methods.Remove(e.RemoveMethod);
            }

            Dictionary<string, int> overloads = new Dictionary<string, int>();

            foreach (var m in methods)
            {
                var methodNode = Resolve(m);

                int ordinal = 0;
                overloads.TryGetValue(m.Name, out ordinal);
                overloads[m.Name] = ordinal + 1;
                methodNode.OverloadOrdinal = ordinal;
                ast.Methods.Add(methodNode);
            }


            var impl = type.GetInterfaces().Reverse().ToList();
            HashSet<System.Type> indirect = new HashSet<System.Type>();
            foreach(var iface in impl)
            {
                foreach(var indirectiface in iface.GetInterfaces())
                {
                    if (!indirect.Contains(indirectiface))
                        indirect.Add(indirectiface);
                }
            }

            foreach (var sub in indirect)
                impl.Remove(sub);

            if(impl != null && impl.Count != 0)
            {
                ast.BaseType = (Object)Resolve(impl[0]);

                if (ast.BaseType != null && ast.BaseType.IsPureReference)
                    ast.BaseType = null;

                if (ast.BaseType != null)
                {
                    for (int i = 1; i < impl.Count; i++)
                        ast.Interfaces.Add((Object)Resolve(impl[i]));
                }
                else
                {
                    for (int i = 0; i < impl.Count; i++)
                        ast.Interfaces.Add((Object)Resolve(impl[i]));
                }

                // TODO Can this error ever happen this way?

                //for (int i = 0; i < ast.Interfaces.Count; i++)
                //{
                //    if (ast.Interfaces[i] == null)
                //        Errors.IncompatibleType(impl[i + (ast.BaseType == null ? 0 : 1)]);
                //}
            }
        }

        public void Merge(Task ast, System.Type type)
        {
            if (!type.IsGenericType)
            {
                ast.Result = new Field
                {
                    Type = BasicTypes.Void,
                    Context = VariableContext.Member
                };
            }
            else
            {
                var gargs = type.GetGenericArguments();

                ast.Result = new Field
                {
                    Type = Resolve(gargs[0]),
                    IsArray = gargs[0].IsArray,
                    Context = VariableContext.Member
                };
            }
        }

        public static Construct ConstructOf(System.Type t)
        {
            if (t == typeof(void))
                return Construct.Void;
            if (t == typeof(object))
                return Construct.Primitive;
            if (t.IsEnum)
                return Construct.Enum;
            else if (t == typeof(string) || t == typeof(System.String))
                return Construct.String;
            else if (t.IsPrimitive)
                return Construct.Primitive;
            else if (t.IsValueType)
                return Construct.Struct;
            else if (typeof(System.Delegate).IsAssignableFrom(t))
                return Construct.Delegate;
            else if (typeof(System.Threading.Tasks.Task).IsAssignableFrom(t))
                return Construct.Task;
            else
                return Construct.Object;
        }
        
        public static Access AccessOf(FieldInfo field)
        {
            int isPublic = (field.GetCustomAttribute<PublicAttribute>() != null ? 1 : 0);
            int isProtected = (field.GetCustomAttribute<ProtectedAttribute>() != null ? 1 : 0);
            int isInternal = (field.GetCustomAttribute<InternalAttribute>() != null ? 1 : 0);
            int isPrivate = (field.GetCustomAttribute<PrivateAttribute>() != null ? 1 : 0);

            if (isPublic + isProtected + isInternal + isPrivate > 1)
                Errors.Generic(field.DeclaringType.FullName + "." + field.Name + " has multiple, conflicting access attributes");
            else if (isPublic == 1)
                return Access.Public;
            else if (isProtected == 1)
                return Access.Protected;
            else if (isInternal == 1)
                return Access.Internal;
            else if (isPrivate == 1)
                return Access.Private;
            else
            {
                if (field.IsPublic) return Access.Public;
                if (field.IsPrivate) return Access.Private;
            }

            return Access.Public;
        }

        public static Access AccessOf(MethodInfo method)
        {
            int isPublic = (method.GetCustomAttribute<PublicAttribute>() != null ? 1 : 0);
            int isProtected = (method.GetCustomAttribute<ProtectedAttribute>() != null ? 1 : 0);
            int isInternal = (method.GetCustomAttribute<InternalAttribute>() != null ? 1 : 0);
            int isPrivate = (method.GetCustomAttribute<PrivateAttribute>() != null ? 1 : 0);

            if (isPublic + isProtected + isInternal + isPrivate > 1)
                Errors.Generic(method.DeclaringType.FullName + "." + method.Name + " has multiple, conflicting access attributes");
            else if (isPublic == 1)
                return Access.Public;
            else if (isProtected == 1)
                return Access.Protected;
            else if (isInternal == 1)
                return Access.Internal;
            else if (isPrivate == 1)
                return Access.Private;
            else
            {
                if (method.IsPublic)
                    return Access.Public;
                else if (method.IsPrivate)
                    return Access.Private;
                else if (method.IsFamily)
                    return Access.Protected;
                else if (method.IsAssembly)
                    return Access.Internal;
                else
                    throw new Exception("What kind of weird access is this? " + method.DeclaringType.FullName + "." + method.Name);
            }

            return Access.Public;
        }

        public static Access AccessOf(PropertyInfo prop)
        {
            int isPublic = (prop.GetCustomAttribute<PublicAttribute>() != null ? 1 : 0);
            int isProtected = (prop.GetCustomAttribute<ProtectedAttribute>() != null ? 1 : 0);
            int isInternal = (prop.GetCustomAttribute<InternalAttribute>() != null ? 1 : 0);
            int isPrivate = (prop.GetCustomAttribute<PrivateAttribute>() != null ? 1 : 0);

            if (isPublic + isProtected + isInternal + isPrivate > 1)
                Errors.Generic(prop.DeclaringType.FullName + "." + prop.Name + " has multiple, conflicting access attributes");
            else if (isPublic == 1)
                return Access.Public;
            else if (isProtected == 1)
                return Access.Protected;
            else if (isInternal == 1)
                return Access.Internal;
            else if (isPrivate == 1)
                return Access.Private;
            else
                return AccessOf(prop.GetMethod);

            return Access.Public;
        }

        public static Access AccessOf(EventInfo ev)
        {
            return AccessOf(ev.AddMethod);
        }

        public MemberNature NatureOf(MemberInfo member)
        {
            var method = member as MethodInfo;
            var ev = member as EventInfo;
            var prop = member as PropertyInfo;

            if (ev != null)
                method = ev.AddMethod;
            if (prop != null)
                method = prop.GetMethod;

            if (member.DeclaringType.Assembly == _primaryAssembly)
            {
                if (member.GetCustomAttribute<StaticAttribute>() != null)
                    return MemberNature.Static;
                else if (member.GetCustomAttribute<AbstractAttribute>() != null)
                    return MemberNature.Abstract;
                else if (member.GetCustomAttribute<VirtualAttribute>() != null)
                    return MemberNature.Virtual;
                else
                    return MemberNature.Instance;
            }
            else if (method != null)
            {
                if (method.IsStatic)
                    return MemberNature.Static;
                else if (method.IsAbstract)
                    return MemberNature.Abstract;
                else if (method.IsVirtual)
                    return MemberNature.Virtual;
                else
                    return MemberNature.Instance;
            }
            else
                return MemberNature.Instance;
        }

        private System.Reflection.Assembly _primaryAssembly;
        private Dictionary<System.Reflection.Assembly, Assembly> _assemblyMap = new Dictionary<System.Reflection.Assembly, Assembly>();
        private Dictionary<System.Type, Type> _typeMap = new Dictionary<System.Type, Type>();
        private Dictionary<CustomAttributeData, Attribute> _attributeMap = new Dictionary<CustomAttributeData, Attribute>();
        private Dictionary<string, Namespace> _namespaceMap = new Dictionary<string, Namespace>();
        private Dictionary<MethodInfo, Constructor> _constructorMap = new Dictionary<MethodInfo, Constructor>();
        private Dictionary<MethodInfo, Method> _methodMap = new Dictionary<MethodInfo, Method>();
        private Dictionary<PropertyInfo, Property> _propertyMap = new Dictionary<PropertyInfo, Property>();
        private Dictionary<EventInfo, Event> _eventMap = new Dictionary<EventInfo, Event>();
    }
}
