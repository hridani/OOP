using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The name can not be null or empty");
                this.name = value;
            }
        }
    }
}
