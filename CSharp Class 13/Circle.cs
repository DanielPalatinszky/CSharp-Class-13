using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    class Circlev1 : Shapev1
    {
        private double radius;

        public Circlev1(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }
    }

    // Ha az ősosztály valamelyik tagja abstract, akkor a leszármazottnak kötelező azt az override kulcsszó használatával megvalósítania (a fordító azonnal szól)
    class Circlev2 : Shapev2
    {
        private double radius;

        public Circlev2(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }
    }

    // Ha nem akarjuk megvalósítani az absztrakt ősosztály adott tagját, akkor a leszármazott is lehet absztrakt
    abstract class Circlev3 : Shapev2
    {

    }

    // Megvalósítja az IShape interface-t
    // Az interface összes metódusát kötelező megvalósítani!
    class Circlev4 : IShapev1
    {
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    // Egyszerre több interface-t meg lehet valósítani!!!
    class Circlev5 : IShapev1, IPrintable
    {
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }

    // Keverjük az interface megvalósítást és a leszármazást
    class Circlev6 : Shapev2, IPrintable
    {
        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
