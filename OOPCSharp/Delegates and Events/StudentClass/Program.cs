using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    public class TestStudentClass
    {
        public static void Main()
        {
            Student student = new Student("Peter", 22);
           
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
