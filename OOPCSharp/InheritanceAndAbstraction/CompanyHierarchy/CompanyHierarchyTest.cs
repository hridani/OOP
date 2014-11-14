using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    class CompanyHierarchyTest
    {
        static void Main(string[] args)
        {
            var motors = new Product("Motors", DateTime.Now, 30);
            var latheMacine = new Product("latheMacine", DateTime.Now, 100);
            var autoWash = new Project("AutoWach", DateTime.Now);
            var transferCNCProgram = new Project("transferCNCProgram", DateTime.Now, "TransferCNCProgram from...");
            transferCNCProgram.CloseProject();
            
            var ivan = new SalesEmployee("Ivan", "Mikov", 10001, 1200, Department.Marketing);
            ivan.AddSales(motors);
            ivan.AddSales(latheMacine);
            Console.WriteLine(ivan);
            Console.WriteLine();

            var mitco = new SalesEmployee("Mitco", "Ivanov", 10002, 1250, Department.Marketing);
            mitco.AddSales(latheMacine);
            mitco.AddSales(motors);

            var titi = new Developer("Titi", "Serov", 10003, 1500, Department.Production);
            titi.AddProject(autoWash);
            titi.AddProject(transferCNCProgram);
            var dari = new Developer("Dari", "Shamanova", 10004, 1600, Department.Production);
            dari.AddProject(transferCNCProgram);
            dari.AddProject(autoWash);
            Console.WriteLine(dari);
            Console.WriteLine();
            var managerGesho = new Manager("Gesho", "Mihailov", 12345, 1800, Department.Marketing);
            managerGesho.AddEploymee(mitco);
            managerGesho.AddEploymee(ivan);
            Console.WriteLine(managerGesho);
            Console.WriteLine();
            var managerPesho = new Manager("Pesho", "Milanov", 12346, 1900, Department.Production);
            managerPesho.AddEploymee(dari);
            managerPesho.AddEploymee(titi);
            Console.WriteLine(managerPesho);
        }
    }
}
