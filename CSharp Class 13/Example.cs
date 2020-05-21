using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    class A
    {
        public virtual void Test()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        public override void Test()
        {
            Console.WriteLine("B");
        }
    }

    class C : B
    {
        public override void Test()
        {
            Console.WriteLine("C");
        }
    }

    //--------------------------------------------------

    class D
    {
        public void Test()
        {
            Console.WriteLine("D");
        }
    }

    class E : D
    {
        public new virtual void Test()
        {
            Console.WriteLine("E");
        }
    }

    class F : E
    {
        public override void Test()
        {
            Console.WriteLine("F");
        }
    }
}
