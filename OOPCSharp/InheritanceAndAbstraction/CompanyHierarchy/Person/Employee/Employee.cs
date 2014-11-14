using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
   
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        public Employee(string firstName, string lastName, int id, decimal salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                Validation.CheckForNegativeOrZero(value, "salary");
                this.salary = value;
            }
        }
        public Department Department { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("\nSalary: {0} BGN, Department: {1}", this.Salary, this.Department);
        }
    }
}
