using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesTest
    {
        static void Main()
        {
            IShape triangle1 = new Triangle(3, 4, 5);
            IShape triangle2 = new Triangle(23, 24, 45);

            IShape rect1 = new Rectangle(2.5, 2);
            IShape rect2 = new Rectangle(3.1, 2.1);
            Circle circle1 = new Circle(5.2);
            Circle circle2 = new Circle(2.2);

            IShape[] shapes = new IShape[6] { triangle1, triangle2, rect1, rect2, circle1, circle2};

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0,-20}: Perimeter: {1:N2}, Area: {2:N2}", shape.GetType().Name, shape.CalculatePerimeter(), shape.CalculateArea());
            }
        }
    }
}
