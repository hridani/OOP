using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    class SalesEmployee : Employee, ISalesEmployee
    {
        private IList<Product> sales;
        
        public SalesEmployee(string firstName, string lastName, int id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
            this.sales = new List<Product>();
        }

        public SalesEmployee(string firstName, string lastName, int id, decimal salary, Department department, IList<Product> sales)
            : this(firstName, lastName, id, salary, department)
        {
            this.sales = sales;
        }

        public void AddSales(Product product)
        {
            sales.Add(product);
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
            string.Format("sales:\n{0}", string.Join("\n", sales));
        }
    }
}
