using System;
[AttributeUsage(AttributeTargets.Struct |
AttributeTargets.Class |
AttributeTargets.Interface |
AttributeTargets.Enum |
AttributeTargets.Method,
AllowMultiple = true)]

    public class VersionAttribute : Attribute
    {
        private int minor;
        private int major;
        public VersionAttribute(int major, int minor)
        {
            this.minor = minor;
            this.major = major;
        }
        
        public override string ToString()
        {
            return string.Format("{0}.{1}", this.major, this.minor);
        }
    }

