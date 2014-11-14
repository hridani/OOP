using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    class Manager:Employee, IManager
    {
        private IList<IPerson> employees = new List<IPerson>();

        public Manager(string firstName, string lastName,int id, decimal salary, Department department)
            :base(firstName, lastName, id, salary, department)
        {
            
        }
        public Manager(string firstName, string lastName, int id, decimal salary, Department department, IList<IPerson> employees)
            : base(firstName, lastName, id, salary, department)
        {
            this.employees = employees;
        }
        
        public IList<IPerson> Employees
        {
            get
            {
                return this.employees;
            }
            set
            {
                Validation.CheckForNull(value, "list of employees");
                this.employees = value;
            }
        }

        public void AddEploymee(IPerson employee)
        {
            this.employees.Add(employee);
        }

        public override string ToString()
        {
            var fullNamesOfEmployees = employees.Select(e => e.FirstName + " " + e.LastName);
            return base.ToString() + "\n" +
            string.Format("Employees:\n{0}", string.Join("\n", fullNamesOfEmployees));
        }

    }
}
