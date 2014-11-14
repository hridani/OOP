namespace School
{
    using System;
    
    public class Student:People
    {
        private uint classNumber;
        
        public Student(string name, uint classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, uint classNumber, string details)
            :base(name, details)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                this.classNumber = value;
            }
        }
    }
}
