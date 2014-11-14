using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
    class DropoutStudent : Student
    {
        private string dropoutReason;
        public DropoutStudent(string fName, string lName, string studentNumber, float averageGrade, string dropoutReason, int age = 0)
            : base(fName, lName, studentNumber, averageGrade, age)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("DropOut reason can not be null!");
                this.dropoutReason = value;
            }
        }

        public override string ToString()
        {
            string student = base.ToString();
            string dropStudent = string.Format(", Dropout reason: {0}", this.DropoutReason);
            return student + dropStudent;
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
