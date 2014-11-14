namespace Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;

        public Customer(string firstName,
                        string middleName,
                        string lastName,
                        string id,
                        string permanentAddress,
                        string mobilePhone,
                        string email,
                        CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.CustomerType = customerType;
            this.Payments = new List<Payment>();
        }
        public Customer(string firtsName,
                        string middleName,
                        string lastName,
                        string id,
                        string permanentAdres,
                        string mobilePhone,
                        string email,
                        CustomerType customerType, IList<Payment> payments)
            : this(firtsName, middleName, lastName, id, permanentAdres, mobilePhone, email, customerType)
        {
            this.Payments = payments;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "firstName");
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "middleName");
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "lastName");
                this.lastName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Validation.CheckForEGN(value, "Id=EGN");
                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "permanentAddress");
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "mobilePhone");
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "email");
                this.email = value;
            }
        }

        public IList<Payment> Payments { get; set; }
        public CustomerType CustomerType { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            if (!Object.Equals(this.FirstName, customer.firstName))
            {
                return false;
            }

            if (!Object.Equals(this.MiddleName, customer.MiddleName))
            {
                return false;
            }

            if (!Object.Equals(this.LastName, customer.LastName))
            {
                return false;
            }

            if (!Object.Equals(this.Id, customer.Id))
            {
                return false;
            }

            if (!Object.Equals(this.PermanentAddress, customer.PermanentAddress))
            {
                return false;
            }

            if (!Object.Equals(this.MobilePhone, customer.MobilePhone))
            {
                return false;
            }

            if (!Object.Equals(this.Email, customer.Email))
            {
                return false;
            }

            if (!Object.Equals(this.CustomerType, customer.CustomerType))
            {
                return false;
            }

            if (!Object.Equals(this.Payments, customer.Payments))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Customer customer1,
                                        Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1,
                                        Customer customer2)
        {
            return !Customer.Equals(customer1, customer2);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Id.GetHashCode()
                   ^ this.PermanentAddress.GetHashCode() ^ this.MobilePhone.GetHashCode() ^ this.Email.GetHashCode() ^ this.CustomerType.GetHashCode()
                   ^ this.Payments.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} EGN:{3} Adress:{4} GSM:{5} e-mail:{6} Customer Type:{7} \n\tPayment: {8}",
                this.FirstName, this.MiddleName, this.LastName, this.Id, this.PermanentAddress, this.MobilePhone, this.Email, this.CustomerType,
                String.Join("\n\tPayment: ", this.Payments));

        }



        public object Clone()
        {
            return new Customer(
               FirstName = (string)this.FirstName.Clone(),
               MiddleName = (string)this.MiddleName.Clone(),
               LastName = (string)this.LastName.Clone(),
               Id = (string)this.Id.Clone(),
               PermanentAddress = (string)this.PermanentAddress.Clone(),
               MobilePhone = (string)this.MobilePhone.Clone(),
               Email = (string)this.Email.Clone(),
               CustomerType = this.CustomerType,
               Payments = new List<Payment>(this.Payments.ToList())
            );
        }

        public int CompareTo(Customer other)
        {
            int result = this.firstName.CompareTo(other.FirstName);
            if (result == 0)
            {
                ulong thisid = ulong.Parse(this.Id);
                result = thisid.CompareTo(ulong.Parse(other.Id));
            }
            return result;
        }
    }
}
