using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public struct Fraction
    {
        private long numerator;
        private long denominator;
        
        public long Numerator
        {
            get { return this.numerator; }
            set 
            {
                checked
                {
                    this.numerator = value;
                }
            } 
        }

        public long Denominator
        {
            get { return this.denominator; }
            set 
            {
                if (value == 0)
                    throw new DivideByZeroException("Denominator can not be zero!");
                checked
                {
                    this.denominator = value;
                }
            } 
        }

        public Fraction(long a, long b)
            :this()
        {
            this.Numerator = a;
            this.Denominator = b;
            //if denominator negativ
            if (this.Denominator < 0)
            {
                this.Numerator = -this.Numerator;
                this.Denominator = -this.Denominator;
            }
        }
        
        private static long getGCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            if (a == 0)
                return b;
            else
                return a;
        }

        private static long getLCD(long a, long b)
        {
            return (a * b) / getGCD(a, b);
        }
        public Fraction GetReduced()
        {
            Fraction modifiedFraction = this;
            long gcd = 0;
            while(Math.Abs(gcd = getGCD(modifiedFraction.Numerator,modifiedFraction.Denominator)) !=1)
            {
                modifiedFraction.Numerator /= gcd;
                modifiedFraction.Denominator /= gcd;
            }
            if(modifiedFraction.Denominator < 0)
            {
                modifiedFraction.Numerator = -modifiedFraction.Numerator;
                modifiedFraction.Denominator = -modifiedFraction.Denominator;
            }
            return modifiedFraction;
        }
        
        public Fraction ToDenominator(long targetDenominator)
        {
            Fraction modifiedFraction = this;
            if (targetDenominator < this.Denominator)
                return modifiedFraction;
            if (targetDenominator % this.Denominator != 0)
                return modifiedFraction;
            if (this.Denominator != targetDenominator)
            {
                long factor = targetDenominator / this.Denominator;
                modifiedFraction.Denominator = targetDenominator;
                modifiedFraction.Numerator *= factor;
            }
            return modifiedFraction;
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            long lcd = getLCD(fr1.Denominator, fr2.Denominator);
            fr1 = fr1.ToDenominator(lcd);
            fr2 = fr2.ToDenominator(lcd);
            return new Fraction(fr1.Numerator + fr2.Numerator, lcd);
        }
        
        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            long lcd = getLCD(fr1.Denominator, fr2.Denominator);
            fr1 = fr1.ToDenominator(lcd);
            fr2 = fr2.ToDenominator(lcd);
            return new Fraction(fr1.Numerator - fr2.Numerator, lcd);
        }

        public double ToDouble()
        {
            return (double)this.Numerator / this.Denominator;
        }
        
        public override string ToString()
        {
            return this.ToDouble().ToString();
        }
   
    }

    class FractionCalculator
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }


