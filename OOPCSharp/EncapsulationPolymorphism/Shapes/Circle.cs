using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape
    {
       public double R { get; set; }

        public Circle(double r)
        {
            this.R = r;
        }

        public double CalculateArea()
        {
            return Math.PI * this.R * this.R;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.R;
        }
    }
}
