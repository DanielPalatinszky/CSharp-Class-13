using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    class Rectanglev2 : Shapev2
    {
        private double a;
        private double b;

        public Rectanglev2(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }
}
