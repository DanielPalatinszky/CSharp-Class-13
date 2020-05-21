using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    class Shapev1
    {
        public virtual double CalculateArea()
        {
            return -1;
        }
    }

    // Az abstract kulcsszó segítségével jelölhetjük egy metóduson, hogy absztrakt, azaz nem tudjuk még, hogy mit csinál
    // Ha egy osztálynak van abstract tagja, akkor az egész osztályt az abstract kulcsszóval absztraktnak kell jelölni
    abstract class Shapev2
    {
        public abstract double CalculateArea();
    }

    // Az abstract osztály tetszőleges tagokat tartalmazhat
    abstract class Shapev3
    {
        protected Shapev3()
        {
        }

        public abstract double CalculateArea();

        public virtual void Test1()
        {

        }

        public void Test2()
        {

        }

        public int Test3 { get; set; }

        private int test4;
    }

    // Az abstract osztálynak abstract tulajdonsága is lehet
    abstract class Shapev4
    {
        public abstract int Test { get; set; }
    }

    // Keverhetjük az interface-t és az abstract osztályt
    // Minden Shapev5 leszármazott egyszerre lesz Shapev5 és IPrintable is!!!
    abstract class Shapev5 : IPrintable
    {
        // Megvalósíthatjuk!
        public void Print()
        {
            Console.WriteLine("Shape");
        }

        // De absztrakttá is tehetjük!
        //public abstract void Print();
    }
}
