using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Gluon
{
    public static class XmlDocReader
    {
        public static XmlElement XMLFromMember(MethodInfo methodInfo)
        {
            // Calculate the parameter string as this is in the member name in the XML
            string parametersString = "";
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                if (parametersString.Length > 0)
                    parametersString += ",";

                parametersString += parameterInfo.ParameterType.FullName;
            }

            if (parametersString.Length > 0)
                return XMLFromName(methodInfo.DeclaringType, 'M', methodInfo.Name + "(" + parametersString + ")");
            else
                return XMLFromName(methodInfo.DeclaringType, 'M', methodInfo.Name);
        }

        public static XmlElement XMLFromMember(MemberInfo memberInfo)
        {
            // First character [0] of member type is prefix character in the name in the XML
            return XMLFromName(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }

        public static XmlElement XMLFromType(Type type)
        {
            return XMLFromName(type, 'T', "");
        }

        public static XmlDocument XMLFromAssembly(Assembly assembly)
        {
            if (_FailCache.ContainsKey(assembly))
                throw _FailCache[assembly];

            try
            {
                if (!_Cache.ContainsKey(assembly))
                    _Cache[assembly] = XMLFromAssemblyNonCached(assembly);

                return _Cache[assembly];
            }
            catch (Exception exception)
            {
                _FailCache[assembly] = exception;
                throw exception;
            }
        }

        private static XmlElement XMLFromName(Type type, char prefix, string name)
        {
            string fullName = prefix + ":" + type.FullName;

            if (!string.IsNullOrEmpty(name))
                fullName += "." + name;

            XmlElement matchedElement = null;
            XmlDocument xmlDocument = XMLFromAssembly(type.Assembly);

            if (xmlDocument == null) return null;

            foreach (XmlElement xmlElement in xmlDocument["doc"]["members"])
            {
                if (xmlElement.Attributes["name"].Value.Equals(fullName))
                {
                    if (matchedElement != null)
                        throw new Exception("Multiple matches to query", null);

                    matchedElement = xmlElement;
                }
            }

            return matchedElement;
        }

        private static XmlDocument XMLFromAssemblyNonCached(Assembly assembly)
        {
            const string prefix = "file:///";
            string assemblyFilename = assembly.CodeBase;

            if (!assemblyFilename.StartsWith(prefix))
                return null;

            var path = Path.ChangeExtension(assemblyFilename.Substring(prefix.Length), ".xml");
            if (!File.Exists(path))
                return null;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            return xmlDocument;
        }
        
        private static Dictionary<Assembly, XmlDocument> _Cache = new Dictionary<Assembly, XmlDocument>();
        private static Dictionary<Assembly, Exception> _FailCache = new Dictionary<Assembly, Exception>();
    }
}
