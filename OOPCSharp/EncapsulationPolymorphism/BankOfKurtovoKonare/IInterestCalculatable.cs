using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    public interface IInterestCalculatable
    {
        decimal CalculateInterestForPeriod(int months);
    }
}
