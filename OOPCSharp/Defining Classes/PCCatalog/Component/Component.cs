using System;
using System.Text;


namespace PCCatalog
{
    class Component
    {
        private string name;
        private decimal price;
        private string details;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Component name can not be null!");
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0) throw new ArgumentException("Component price can not be negative!");
                this.price = value; 
            }
        }
        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public override string ToString()
        {
            StringBuilder outStr = new StringBuilder();
            outStr.AppendLine();
            outStr.AppendLine("\tName: " + this.Name).AppendLine("\tPrice: " + this.Price.ToString("F"));
            outStr.Append((this.Details != null) ? ("\tDetails: " + this.Details):"" );
            return outStr.ToString();
        }
    }
}
