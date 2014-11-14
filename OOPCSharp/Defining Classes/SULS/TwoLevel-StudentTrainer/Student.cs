using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
    public abstract class Student:Person
    {
        private string studentNumber;
        private float averageGrade;

        public string StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (null == value) throw new ArgumentNullException("Student number can not be null!");
                this.studentNumber = value;
            }
        }
        public float AverageGrade
        {
            get { return this.averageGrade; }
            set { this.averageGrade = value; }
        }

        public Student(string fname, string lname, string studentNumber, int age=0):
            base(fname,lname,age)
        {
            this.StudentNumber = studentNumber;
        }
        public Student(string fname, string lname, string studentNumber,float averageGrade,  int age = 0) :
            base(fname, lname, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }
        public Student(string fname, string lname, int age = 0) :
            base(fname, lname, age) {}

        public override string ToString()
        {
            string person= base.ToString();
            string student = string.Format(", Student number: {0}, Average grade: {1}", this.StudentNumber, this.AverageGrade);
            return person + student;
        }
        
    }
}
