namespace School
{
    using System;
    using System.Collections.Generic;
    public class Discipline
    {
        private string name;
        private int numberOfLectures;
        private List<Student> students = new List<Student>();
        private string detail;

        public Discipline(string name, int numberOfLectures, string detail=null )
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.Detail = detail;
        }

        public Discipline(string name, int numberOfLectures, List<Student> students, string detail=null)
            : this(name, numberOfLectures, detail)
        {
            this.students = students;
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
                   
        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("THe number of lecture must be integer number greater than zero.");
                }
                this.numberOfLectures = value;
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
        
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }
    }
}
