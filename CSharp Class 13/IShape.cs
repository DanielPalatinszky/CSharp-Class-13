using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    // Konvenció szerint I betűvel kezdjük a nevét
    // Egy interface-ben nem kell kiírni, hogy public a metódus, mivel alapértelmezetten az
    // Egy interface-ben nem kell kiírni, hogy abstract a metódus, mivel alapértelmezetten az
    interface IShapev1
    {
        double CalculateArea();
    }

    // Interface tulajdonságot is tartalmazhat
    interface IShapev2
    {
        int Test { get; set; }
    }
}
