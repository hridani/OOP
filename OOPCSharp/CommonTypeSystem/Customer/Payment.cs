namespace Customer
{
    using System;

    class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validation.CheckForNegativeOrZero(value, "price");
                this.price = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "productName");
                this.productName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.ProductName, this.Price);
        }
    }
}
