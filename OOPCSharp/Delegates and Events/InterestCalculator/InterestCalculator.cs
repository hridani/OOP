using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest
{
    public delegate decimal CalculateInterest(decimal money, decimal interest, int years); 
    class InterestCalculator
    {
        private decimal money;
        private decimal interest;
        private int years;
        private CalculateInterest calFunc;
        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest calcilateFunc)
        {
            this.money=money;
            this.interest=interest;
            this.years=years;
            this.calFunc=calcilateFunc;
        }
        public override string ToString()
        {
            return string.Format("{0:F4}",this.calFunc(money,interest,years));
        }
    }
        
  
}
