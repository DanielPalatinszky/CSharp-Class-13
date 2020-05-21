using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_13
{
    // Leszármazik az IPrintable-ből, így ha valaki megvalósítja az IGraphicsPrintable-t, akkor az IPrintable-t is meg kell valósítania!
    interface IGraphicsPrintable : IPrintable
    {
        void GraphicsPrint();
    }
}
