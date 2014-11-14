using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle:BasicShape
    {
        // 3 sides
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle (double sidea, double sideb, double sidec)
            :base()
	    {
            this.SideA=sidea;
            this.SideB=sideb;
            this.SideC=sidec;
            if(this.IsCheckForValidTriangle()==false)
                throw new ArithmeticException("Invalid triangle's sizes.");
            this.Width = this.SideA;
            this.Height = 2 * CalculateArea() / this.sideA;
        }

        public double SideA
        {
            get 
            { 
                return this.sideA; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be positive number.");
                }
                this.sideA = value;
            }
        }
        public double SideB
        {
            get
            {
                return this.sideB;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be positive number.");
                }
                this.sideB = value;
            }
        }
        
        public double SideC
        {
            get
            {
                return this.sideC;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be positive number.");
                }
                this.sideC = value;
            }
        }
               
        public override double CalculateArea()
        {
            double s = CalculatePerimeter() / 2;
            return Math.Sqrt(s * (s - this.SideA) * (s - this.SideB) * (s - this.SideC));
        }

        public override double CalculatePerimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }
        
        private bool IsCheckForValidTriangle()
        {
            if (this.SideA >= this.SideC + this.SideB ||
                    this.SideB >= this.SideC + this.SideA ||
                    this.SideC >= this.SideB + this.SideB)
            {
               return false;
            }
            else
            {
                return true;
            }
        }
    }
}
