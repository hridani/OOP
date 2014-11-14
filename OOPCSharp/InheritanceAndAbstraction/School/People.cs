namespace School
{
    using System;
    
    public abstract class People
    {
        private string name;
        private string detail;

        public People(string name)
        {
            this.name = name;
        }

        public People(string name, string detail)
            :this(name)
        {
            this.Detail = detail;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name can not be null or empty!");
                }
                this.name = value;
            }
        }

        public string Detail
        {
            get
            {
                return this.detail;
            }
            set
            {
                if (String.Empty == value)
                {
                    throw new ArgumentNullException("The detail can not be an empty string");
                } 
                this.detail = value;
            }
        }
    }
}
