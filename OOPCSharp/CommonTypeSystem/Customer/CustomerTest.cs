using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class CustomerTest
    {
        static void Main()
        {
            Payment wood = new Payment("Wood", 324);
            Payment cheese = new Payment("Cheese", 6.19m);
            Payment oil = new Payment("Oil", 1.89m);
            Payment diesel = new Payment("Diesel", 2.57m);
            Payment cutter = new Payment("Cutter", 98.99m);
            Payment sugar = new Payment("Sugar", 2.34m);
            IList<Payment> daniPayment = new List<Payment>()
            {
                cheese,
                oil,
                sugar
            };

            IList<Payment> georgiPayment = new List<Payment>()
            {
                wood,
                diesel,
                cutter
            };

            Customer dani = new Customer("Dani", "Atanasova", "Stanisheva", "6905044453", "Plovdiv,Slavianska 95",
                                        "0887123456", "dast@abv.bg", CustomerType.Golden);
            dani.Payments = daniPayment;

            Customer daniSt = new Customer("Dani", "Atanasova", "Stanisheva", "6905044453", "Plovdiv,Slavianska 95",
                                            "0887123456", "dast@abv.bg", CustomerType.Golden, daniPayment);

            Customer georgi = new Customer("Georgi", "Petrov", "Georgiev", "7212025633", "Montana, Hristo Botev 5A",
                                            "0888987654", "georgi@gmail.com", CustomerType.OneTime, georgiPayment);


            Console.WriteLine(dani);
            if (dani != georgi)
            {
                Console.WriteLine(georgi);
            }
            if (dani.Equals(daniSt))
            {
                Console.WriteLine("{0} \nequals \n{1}", dani, daniSt);
            }
            daniSt.Payments = georgiPayment;
            daniSt.Id = "6405044453";
            if (dani == daniSt)
            {
                Console.WriteLine("{0} equals {1}", dani.FirstName, daniSt.FirstName);
            }
            else
            {
                Console.WriteLine("{0} not equals {1}", dani.FirstName, daniSt.FirstName);
            }
            Customer georgiClone = (Customer)georgi.Clone();
            georgiClone.FirstName = "Joro";
            georgiClone.Payments[georgiClone.Payments.IndexOf(georgiClone.Payments.First())] = cheese;
            Console.WriteLine(georgiClone);

            Customer[] customers = new Customer[]
            {
                dani,
                georgi,
                daniSt,
                georgiClone
            };
            Array.Sort(customers);
            foreach (var c in customers)
            {
                Console.WriteLine("{0}, {1}", c.FirstName, c.Id);
            }
        }
    }
}
