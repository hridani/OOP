using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class BankOfKurtovoKonareTester
    {
        static void Main()
        {
            Customer dani = new IndividualCustomer("Dani", "7804064404");
            Customer adp = new CompaniesCustomer("ADP", "1234567");
            Account daniLoanAccount = new LoanAccount(dani, 1020, 12);
            Account adpLoanAccount = new LoanAccount(adp, 10234, 12.3m);
            Console.WriteLine("Loan Account");
            Console.WriteLine("{0} Interest for is : {1:f2}", dani.Name, daniLoanAccount.CalculateInterestForPeriod(4));
            Console.WriteLine("{0} Interest for is : {1:f2}", adp.Name, adpLoanAccount.CalculateInterestForPeriod(2));
            Account daniDepositAccount = new DepositAccount(dani, 10000, 12m);
            Account adpDepositAccount = new DepositAccount(adp, 12000, 12m);
            Console.WriteLine("Deposit Account");
            Console.WriteLine("{0} Interest for is : {1:f2}", dani.Name, daniDepositAccount.CalculateInterestForPeriod(4));
            Console.WriteLine("{0} Interest for is : {1:f2}", adp.Name, adpDepositAccount.CalculateInterestForPeriod(2));
            Account daniMortgageAccount = new MortgageAccount(dani, 10000, 12m);
            Account adpMortgageAccount = new MortgageAccount(adp, 10000, 12m);
            Console.WriteLine("Mortgage Account");
            Console.WriteLine("{0} Interest for is : {1:f2}", dani.Name, daniMortgageAccount.CalculateInterestForPeriod(4));
            Console.WriteLine("{0} Interest for is : {1:f2}", adp.Name, adpMortgageAccount.CalculateInterestForPeriod(2));

        }
    }
}
