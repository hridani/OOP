using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    class HumanClass
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan","Petrov","340556"),
                new Student("Dima","Stanislavova","431234"),
                new Student("Anelia","Ivanova","347685"),
                new Student("Petur","Nikolov","435678"),
                new Student("Christo","Milev","442343"),
                new Student("Jan","Velev","123567"),
                new Student("Marusa","Lilova","987645"),
                new Student("Marina","Gilva","456786"),
                new Student("Georgi","Gergiev","349859"),
                new Student("Malin","Didev","567890"),
            };
            
            // sorted students
            var sortedStudentsByFacultyNumberAcd =
               from student in students
               orderby student.FacultyNumber
               select student;
            Console.WriteLine("Sorted Students:");
            foreach (var student in sortedStudentsByFacultyNumberAcd)
            {
                Console.WriteLine(student);
            }

            
            List<Worker> workers = new List<Worker>
            {
                new Worker("Petera", "Brown", 250, 8),
                new Worker("Milkaa", "Ivanova", 250, 8),
                new Worker("Ivan","Petrov", 430, 5),
                new Worker("Vasila", "Angelov", 200, 6),
                new Worker("Mihaila", "Petrov", 350, 8),
                new Worker("Todora", "Genchev", 150, 6),
                new Worker("Ana", "Nikolova", 150, 8),
                new Worker("Anita", "Ivanova", 500, 4),
                new Worker("Angela", "Georgiev", 300, 8),
                new Worker("Boris", "Asenov", 320,8 ),
            };

            // sorted workers
            var sortedWorkerssByPaymentPerHourDec =
               from worker in workers
               orderby worker.MoneyPerHour() descending
               select worker;
            
            Console.WriteLine("\nSorted Workers: ");
            Console.WriteLine(string.Join("\n", sortedWorkerssByPaymentPerHourDec.Select(w => w.ToString())));
        }
    }
}
