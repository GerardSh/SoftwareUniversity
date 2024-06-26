﻿using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }  

        public override double CalculateArea() => Math.PI * Math.Pow(radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * radius;

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
