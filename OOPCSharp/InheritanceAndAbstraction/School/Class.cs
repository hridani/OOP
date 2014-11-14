using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class
    {
        private string textIdentifier;
        private List<Teacher> teachers = new List<Teacher>();
        private string detail;

        public Class(string textIdentifier,string detail = null)
        {
            this.TextIdentifier = textIdentifier;
            this.Detail = detail;
        }

        public Class(string textIdentifier, List<Teacher> teachers, string detail = null)
            :this(textIdentifier, detail)
        {
            this.teachers = teachers;
           
        }

        public string TextIdentifier
        {
            get
            {
                return this.textIdentifier;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The textIdentifier can not be null or empty!");
                }
                this.textIdentifier = value;
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

        public void  AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }
        
    }
}
