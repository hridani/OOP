using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS
{
    class SULSTest
    {
        static void Main(string[] args)
        {
            Student LI = new DropoutStudent("Lili", "Lolova", "1200", (float)5.67, "have baby");
            Student CI = new GraduateStudent("Christo", "Ivanov", "1001", (float)3.16, 22);
            Student DS = new GraduateStudent("Danail", "Slivov", "1010", (float)5.22, 18);
            Student GF = new GraduateStudent("Georgi", "filev", "1034", (float)4.23);
            Student IG = new DropoutStudent("Ivan", "Grigorov", "1267", (float)4.33, "like play");
            Trainer MP = new JuniorTrainer("Mario", "Peshev", 33);
            Trainer VG = new SeniorTrainer("Vlado", "Geogiev", 25);
            Trainer SN = new SeniorTrainer("Svetlin", "Nakov");
            Trainer IB = new JuniorTrainer("Ivan", "Bankov");
            CurrentStudent VP = new OnlineStudent("Valery", "Petrov", "1578", (float)4.55, 23);
            VP.CurrentCourses.Add("PHP");
            VP.CurrentCourses.Add("HTML/CSS");
            CurrentStudent LN = new OnlineStudent("Lubo", "Neikov", "1002", (float)4.35, 38);
            LN.CurrentCourses.Add("JavaScript");
            CurrentStudent BG = new OnsiteStudent("Bilana", "Boteva", "1008", (float)5.85, 19);
            List<Person> persons = new List<Person>() { MP,VG,SN,IB,CI,DS,GF,LI,IG,VP,LN,BG};
                   
           persons.Where(p => p is CurrentStudent).OrderBy(p => ((Student)p).AverageGrade).ToList().ForEach(p => Console.WriteLine(p.ToString()));
           var currentStudents = from person in persons
                                 where person is CurrentStudent
                                 orderby (((Student)person).AverageGrade)
                                 select person;
           foreach (var st in  currentStudents)
           {
               Console.WriteLine(st.ToString());
           }
           
        }
    }
}
