using System;
namespace Interest
{
    class TestInterestCalculator
    {
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            return sum * (1 + (interest / 100) * years);
        }
        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            byte n = 12;
            return sum * (decimal)Math.Pow((double)(1 + (interest / 100) / n), n * years);
        }

        static void Main()
        {
            InterestCalculator compInterest = new InterestCalculator(500m, 5.6m, 10, GetCompoundInterest);
            Console.WriteLine(compInterest);

            InterestCalculator simpInterest = new InterestCalculator(2500m, 7.2m, 15, GetSimpleInterest);
            Console.WriteLine(simpInterest);
        }
    }
}