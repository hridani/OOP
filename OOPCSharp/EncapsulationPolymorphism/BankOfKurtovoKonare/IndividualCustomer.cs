namespace BankOfKurtovoKonare
{
    using System;
    using System.Text.RegularExpressions;

    public class IndividualCustomer : Customer
    {
        private string egn;
        public IndividualCustomer(string name, string egn)
            : base(name)
        {
            this.Egn = egn;
        }

        public string Egn
        {
            get
            {
                return this.egn;
            }
            set
            {
                Regex regex = new Regex(@"^[0-9]{10}$");
                bool isTenDigit = regex.IsMatch(value);
                if (!isTenDigit)
                {
                    throw new ArgumentException("Invalid argument. Use only 10 digits", value);
                }

                this.egn = value;
            }
        }
    }
}
