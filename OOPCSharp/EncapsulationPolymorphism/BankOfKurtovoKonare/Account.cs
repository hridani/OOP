using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    public abstract class Account : IInterestCalculatable, IDeposit
    {
        private Customer customer;
        private decimal balance;
        private decimal mountInterest;

        public Account(Customer customer, decimal balance, decimal yearInterest)
        {
            this.Customer = customer;
            this.mountInterest = yearInterest / 12 / 100;
            this.Balance = balance;

        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The customer can not be null");
                this.customer = value;
            }
        }

        public decimal MountInterest
        {
            get
            {
                return this.mountInterest;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The should be positive number.", "mountInterest");
                this.mountInterest = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public virtual decimal CalculateInterestForPeriod(int periodByMonths)
        {
            return this.Balance * this.MountInterest * periodByMonths;
        }

        public virtual void DepositSum(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("The sum can be positive number.");
            }
            this.Balance = +sum;
        }
    }
}
