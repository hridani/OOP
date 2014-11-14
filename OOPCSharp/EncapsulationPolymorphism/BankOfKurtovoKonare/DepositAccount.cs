using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    public class DepositAccount : Account, IWithdraw
    {
        public DepositAccount(Customer customer, decimal balance, decimal yearInterest)
            : base(customer, balance, yearInterest)
        {

        }

        public override decimal CalculateInterestForPeriod(int periodByMonths)
        {
            if (this.Balance <= 1000)
                return 0;
            return base.CalculateInterestForPeriod(periodByMonths);
        }

        public void WithdrawSum(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("The sum can be positive number.");
            }

            if (this.Balance < sum)
            {
                throw new ArithmeticException("Insufficient amount.");
            }

            this.Balance = -sum;
        }

    }
}
