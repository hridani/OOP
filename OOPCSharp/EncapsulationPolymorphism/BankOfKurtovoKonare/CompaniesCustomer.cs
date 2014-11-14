namespace BankOfKurtovoKonare
{
    using System;
    using System.Text.RegularExpressions;

    class CompaniesCustomer:Customer
    {
        private string eic;
        public CompaniesCustomer(string name, string eic)
            : base(name)
        {
            this.Eic = eic;
        }

        public string Eic
        {
            get
            {
                return this.eic;
            }
            set
            {
                Regex regex = new Regex(@"^[0-9]{7}$");
                bool isSevenDigit = regex.IsMatch(value);
                if (!isSevenDigit)
                {
                    throw new ArgumentException("Invalid argument. Use only 7 digits", value);
                }

                this.eic = value;
            }
        }
    }
}
