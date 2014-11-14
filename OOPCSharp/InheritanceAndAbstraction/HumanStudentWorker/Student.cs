namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   // using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Student:Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, string faultyNumber)
            : this(firstName, lastName)
        {
            this.FacultyNumber = faultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                //if (value.Length < 5 || value.Length > 10)
                //{
                //    throw new ArgumentException("The faultyNumber can be with 5-10 digits");
                //}
              
                //if(!value.All(char.IsLetterOrDigit))
                //{
                //     throw new ArgumentException("Invalid argument. Use only digits or letters");
                //}

                Regex regex = new Regex(@"^[0-9A-Za-z]{5,10}$");
                bool isDigitOrLetter = regex.IsMatch(value);
                if(!isDigitOrLetter)
                {
                    throw new ArgumentException("Invalid argument. Use only digits or letters", value);
                }
                
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " - " + this.FacultyNumber;
        }
    }
}
