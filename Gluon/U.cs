using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gluon
{
    public static class U
    {
        public static Guid HashNameToGuid(Guid baseId, string s)
        {
            var bytes = baseId.ToByteArray();

            var stringBytes = Encoding.ASCII.GetBytes(s);

            for (int i = 0; i < stringBytes.Length; i++)
            {
                bytes[i % 16] = (byte)(bytes[i % 16] ^ stringBytes[i]);
            }

            return new Guid(bytes);
        }

        public static Type Deref(Type t)
        {
            if (t.IsByRef)
                return t.GetElementType();
            else
                return t;
        }

        public static void WriteFileIfModified(string path, string contents)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, contents);
            else
            {
                var current = File.ReadAllText(path);
                if (current == contents)
                    return;
                File.WriteAllText(path, contents);
            }
        }

        public static bool IsOverride(MethodInfo m)
        {
            var baseType = m.DeclaringType.GetInterfaces().FirstOrDefault();

            if (baseType == null) return false;

            var flags = m.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic;
            flags = flags | BindingFlags.Instance;
            var paramTypes = m.GetParameters().Select(p => p.ParameterType).ToArray();
            return (baseType.GetMethod(m.Name, flags, null, paramTypes, null) != null);
        }

        //public static bool IsGluonObject(Type t)
        //{
        //    if (typeof(GluonObject).IsAssignableFrom(t))
        //        return true;

        //    return t.IsInterface && t != typeof(IUnknown) && t != typeof(IObject);
        //}

        public static string GetAbsolutePath(string path)
        {
            var uri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), path));
            return uri.AbsolutePath.Replace('/', '\\');
        }

        public static string GetRelativePath(string path, string relativeTo)
        {
            if (!relativeTo.EndsWith("\\"))
                relativeTo += "\\";

            Uri pathUri;
            Uri relativeToUri;
            if (!Path.IsPathRooted(path))
                pathUri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), path));
            else
                pathUri = new Uri(path);

            if (!Path.IsPathRooted(relativeTo))
                relativeToUri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), relativeTo));
            else
                relativeToUri = new Uri(relativeTo);

            return relativeToUri.MakeRelativeUri(pathUri).ToString().Replace('/', '\\');
        }

        public static string RootPath(string p)
        {
            if (!Path.IsPathRooted(p))
                return Path.Combine(Directory.GetCurrentDirectory(), p);
            else
                return p;
        }

        public static string StringLiteral(string i_string)
        {
            return Regex.Replace(i_string, _RegexEscapes, Match);
        }

        public static string CharLiteral(char c)
        {
            return c == '\'' ? @"'\''" : string.Format("'{0}'", c);
        }

        public static string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            else if (s.Length == 1)
                return s.ToUpper();
            else
                return char.ToUpper(s[0]) + s.Substring(1);
        }
        
        public static string TrimIndent(this string s)
        {
            int smallest = int.MaxValue;

            foreach(var match in _IndentRegex.Matches(s).OfType<Match>())
                smallest = Math.Min(smallest, match.Length);

            return _IndentRegex.Replace(s, m =>
            {
                return new string(' ', m.Length - smallest);
            });
        }

        private static string Match(Match m)
        {
            string match = m.ToString();
            if (_ReplaceDict.ContainsKey(match))
            {
                return _ReplaceDict[match];
            }

            throw new NotSupportedException();
        }

        static U()
        {
            _ReplaceDict.Add("\a", @"\a");
            _ReplaceDict.Add("\b", @"\b");
            _ReplaceDict.Add("\f", @"\f");
            _ReplaceDict.Add("\n", @"\n");
            _ReplaceDict.Add("\r", @"\r");
            _ReplaceDict.Add("\t", @"\t");
            _ReplaceDict.Add("\v", @"\v");

            _ReplaceDict.Add("\\", @"\\");
            _ReplaceDict.Add("\0", @"\0");

            //The SO parser gets fooled by the verbatim version 
            //of the string to replace - @"\"""
            //so use the 'regular' version
            _ReplaceDict.Add("\"", "\\\"");
        }

        static readonly Regex _IndentRegex = new Regex(@"(?<=^|\n) +", RegexOptions.Compiled);
        const string _RegexEscapes = @"[\a\b\f\n\r\t\v\\""]";
        static readonly IDictionary<string, string> _ReplaceDict
            = new Dictionary<string, string>();
    }
}
