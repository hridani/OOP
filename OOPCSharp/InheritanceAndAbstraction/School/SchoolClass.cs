

namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SchoolClass
    {
        static void Main()
        {
            // studetnts
            List<Student> students=new List<Student>
            {
                new Student("Герги Иванов", 1),
                new Student("Марина Петрова", 2),
                new Student("Вили Стоянова", 10),
                new Student("Петър Колев", 24),
                new Student("Стела Маринова", 4)
            };
            
            // disciplines
            var html = new Discipline("HTML", 6);
            html.AddStudent(students[0]);
            html.AddStudent(students[2]);
            html.AddStudent(students[4]);
            html.Detail = "HTML coursses";
            
            var css = new Discipline("C#", 5);
            css.AddStudent(students[0]);
            css.AddStudent(students[1]);
            css.AddStudent(students[2]);
            
            var java = new Discipline("Java", 4);
            java.AddStudent(students[1]);
            java.AddStudent(students[3]);
            java.AddStudent(students[4]);

            var javaScript = new Discipline("JavaScript", 5, students,"само един път в седмицата");
            
            // teachers
            var webDevelopmentTeacher = new Teacher("Настя гергиева");
            webDevelopmentTeacher.AddDiscipline(html);
            webDevelopmentTeacher.AddDiscipline(css);
            webDevelopmentTeacher.AddDiscipline(javaScript);
            
            var JavaDevelopmentTeacher = new Teacher("Тодор Петров");
            JavaDevelopmentTeacher.AddDiscipline(java);

            // classes
            var classA = new Class("A", new List<Teacher> { webDevelopmentTeacher, JavaDevelopmentTeacher },"1 ново");

                
        }
    }
}
