using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
    public abstract class Person
    {
        private string fName;
        private string lName;
        private int age;
       
        public string FName
        {
            get { return this.fName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Fisrt Name is empty!");
                this.fName = value;
            }
        }
        
        public string LName
        {
            get { return this.lName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Last Name is empty!");
                this.lName = value;
            }
        }
        
        public int Age
        {
            get { return this.age; }

            set
            {
                if (value < 0) throw new ArgumentException("Age can not be negative");
                this.age = value;
            }
        }

        public Person(string fname, string lname)
        {
            this.FName = fname;
            this.LName = lname;
            
        }
       
        public Person(string fname, string lname, int age)
            : this(fname,lname)
        {
            this.Age=age;
        }

        
        public override string ToString()
        {
            string outstr = GetType().Name + "Name: " + this.FName +" "+ this.LName;
            outstr+=(this.Age > 0) ? ", "+this.Age + " years old" : "";
            return outstr;
        }
    }
}
