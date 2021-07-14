using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * radius * 2;
        }

        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
