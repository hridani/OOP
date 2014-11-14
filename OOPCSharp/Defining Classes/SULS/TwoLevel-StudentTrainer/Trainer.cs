using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SULS
{
    public abstract class Trainer:Person
    {
        public Trainer(string fname, string lname, int age = 0) 
             : base(fname, lname, age) { }

        public void CreateCourse(string courseName)
        {
        Console.WriteLine("Course {0} created", courseName);
        }
    }
}
