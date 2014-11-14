using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;
        
        public BasicShape()
        {
        }

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get 
            { 
                return this.width; 
            }
            
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be positive number.");
                }
                this.width = value;
            }
        }
        
        public double Height
        {
            get 
            { 
                return this.height; 
            }
            
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be positive number.");
                }
                this.height = value;
            }
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
