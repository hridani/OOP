using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        public Customer(string firstName, string lastName, int id, decimal netPurchaseAmount)
            :base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount { get; set; }

        public void AddAmount(decimal newAmount)
        {
            this.NetPurchaseAmount+=newAmount;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Amount: {0}", this.NetPurchaseAmount); 
        }
    }
}
