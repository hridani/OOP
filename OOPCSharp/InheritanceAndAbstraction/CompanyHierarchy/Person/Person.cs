using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                Validation.CheckForNegativeOrZero(value, "id");
                this.id=value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "firstName");
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                Validation.CheckForNullOrEmptyString(value, "firstName");
                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - ID: {2}", this.FirstName, this.LastName, this.Id);
        }
    }
}
