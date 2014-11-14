using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal yearInterest)
            : base(customer, balance, yearInterest)
        {
        }

        public override decimal CalculateInterestForPeriod(int periodByMonths)
        {
            int nullInteresetPeriod = (this.Customer.GetType().Name == "IndividualCustomer") ? 3 : 2;

            return (periodByMonths - nullInteresetPeriod <= 0) ? 0 : base.CalculateInterestForPeriod(periodByMonths);
        }
    }
}
