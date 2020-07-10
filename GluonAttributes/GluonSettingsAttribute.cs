using System;

namespace Gluon
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class GluonSettingsAttribute : Attribute
    {
        public string ProjectName { get; private set; }
        public string CppProjectName { get; private set; }
        public string CsProjectName { get; private set; }

        public GluonSettingsAttribute()
        {
        }
        
        public GluonSettingsAttribute(string projectName)
        {
            ProjectName = projectName;
            CppProjectName = ProjectName;
            CsProjectName = ProjectName;
        }

        public GluonSettingsAttribute(string cppProjectName = null, string csProjectName = null)
        {
            CppProjectName = cppProjectName;
            CsProjectName = csProjectName;
        }
    }
}
