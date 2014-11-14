using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
          public abstract class CurrentStudent : Student
          {
            private IList<String> currentCourses;
            public CurrentStudent(string fName, string lName, string studentNumber, float averageGrade, int age = 0)
            : base(fName, lName, studentNumber, averageGrade, age)
            {
                this.CurrentCourses = new List<String>();
            }
            
            public IList<String> CurrentCourses
            {
                get { return this.currentCourses; }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException("Courses can not be null!");
                    this.currentCourses = value;
                }
            }
            public override string ToString()
            {
                string student = base.ToString();
                string courses="";
                if(this.CurrentCourses.Count != 0)
                    courses = string.Format(" Courses: {0}",String.Join(", ", this.CurrentCourses));
                return student + courses;
            }
    }
     
}
