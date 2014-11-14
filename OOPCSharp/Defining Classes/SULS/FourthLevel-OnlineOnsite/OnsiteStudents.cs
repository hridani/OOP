using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
    
    
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;
        public OnsiteStudent(string fName, string lName, string studentNumber, float averageGrade, int age = 0, int numberOfVisits = 0)
            : base(fName, lName, studentNumber, averageGrade, age)
        {
            this.NumberOfVisits = numberOfVisits;
        }
        public int NumberOfVisits
        {
            get { return numberOfVisits; }
            set
            {
                if (value < 0) throw new ArgumentException("Visits number can not be negative!");
                numberOfVisits = value;
            }
        }
        public override string ToString()
        {
            string student = base.ToString();
            string visits = string.Format(" Visits: {0}", this.numberOfVisits);
            return student + visits;
        }
    }
}
