using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class MortgageAccount:Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal yearInterest)
            : base(customer, balance, yearInterest)
        {
        }

        public override decimal CalculateInterestForPeriod(int periodByMonths)
        {
            if(this.Customer.GetType().Name == "IndividualCustomer")
            {
                if (periodByMonths <= 6)
                    return 0;
                else
                    return base.CalculateInterestForPeriod(periodByMonths);
            }
            else
            {
                if (periodByMonths <= 12)
                    return base.CalculateInterestForPeriod(periodByMonths)/2;
                else
                    return base.CalculateInterestForPeriod(periodByMonths);
            }
       }
    }
}
