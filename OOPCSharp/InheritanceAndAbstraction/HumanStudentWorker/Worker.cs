using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    class Worker:Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
       
        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, decimal weekSelary, decimal workHoursPerDay)
            :this(firstName, lastName)
        {
            this.WeekSalary = weekSelary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WorkHoursPerDay
        {
            get 
            { 
                return workHoursPerDay; 
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The argument must not to be negative or zero.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get 
            { 
                return weekSalary; 
            }
            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("The argument must not to be negative or zero.");
                }
                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (5 * this.workHoursPerDay);
        }

        public override string ToString()
        {
            return base.ToString() + " - " + this.MoneyPerHour().ToString("F2");
        }
    }
}
