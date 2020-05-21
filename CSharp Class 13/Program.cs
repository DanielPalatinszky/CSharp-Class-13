using System;
using System.Runtime.InteropServices;

namespace CSharp_Class_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // A virtual-override természetesen tetszőleges mély osztályhierarchiában működik (lásd: Example.cs)
            A a1 = new A();
            a1.Test(); // A

            A a2 = new B();
            a2.Test(); // B

            A a3 = new C();
            a3.Test(); // C

            // Érdekesség: a new és virtual kulcsszó együtt is használható (lásd: Example.cs)
            // Ezáltal egyszerre rejtjük el az ősosztály metódusát és jelöljük virtuálisnak az aktuális metódust
            D d1 = new E();
            d1.Test(); // D

            D d2 = new F();
            d2.Test(); // D

            E e1 = new F();
            e1.Test(); // F

            //--------------------------------------------------

            // Eddig beszéltünk az egységbezárásról, az öröklésről és a polimorfizmusról
            // Most az OOP utolsó alaptételéről, az absztrakcióról lesz szó

            // Mit jelent az absztrakció?
            // Képzeljük el, hogy van egy nagyon részletes tervrajzunk egy autóról! Ezen a tervrajzon rajta van minden: a kábelezés, a méretek, a motor paraméterei stb.
            // Nekünk nincs szükségünk egy ilyen komplex tervrajzra, mivel csak az autó méreteit szeretnénk látni, ezért absztrahálnunk (absztrakciót hajtunk végre). Elhagyjuk a számunkra lényegtelen részleteket!
            // Keletkezik egy olyan tervrajz, amin csak az autó méretei vannak, így sokkal egyszerűbben tudunk a méretekkel dolgozni. Nem zavarnak az egyéb, számunkra felesleges részletek!
            // Most szeretnénk csak az autó formatervével foglalkozni, ezért absztrahálnunk, azaz most elhagyjuk a méreteket!
            // Keletkezik egy rajz, amin csak az autó formaterve van rajta, így sokkal egyszerűbben tudjuk az autó formáját alakítani. Nem zavarnak az egyéb, számunkra felesleges részletek!
            // Tehát az absztrakció lényege, hogy a lényegtelen részleteket, amiket csak alacsonyabb szinteken akarunk/tudunk megadni, azokat elhagyjuk!

            // Múlt órán valójában találkoztunk vele! Pontosabban az absztrakció problémájával!
            // Nézzük meg újra a formákat:
            Shapev1 shape1 = new Circlev1(2);
            Console.WriteLine(shape1.CalculateArea()); // Teljesen jól működik

            Shapev1 shape2 = new Shapev1();
            Console.WriteLine(shape2.CalculateArea()); // Semmi értelme, mivel a Shapev1 önmagában egy érvénytelen forma

            // Az a baj, hogy a Shapev1-nek meg kell mondania, hogy mit csinál a CalculateArea
            // Pedig egy meg nem nevezett forma esetén, mint a Shapev1 ezt nem igazán tudjuk értelmesen megadni
            // Absztrahálnunk kéne ezt az információt és rábízni az alacsonyabb szintekre (a leszármazottakra) ennek a megadását

            // De hogyan?
            // Használjuk az abstract és override kulcsszavakat:
            Shapev2 shape3 = new Circlev2(2);
            Console.WriteLine(shape3.CalculateArea()); // Pontosan ugyanúgy működik, mint eddig

            // Mivel a Shapev2 abstract, ezért nem hozhatunk létre példányt belőle
            //Shapev2 shape4 = new Shapev2(); // Nem jó

            // Probléma megoldva, azaz innentől senki nem hozhat létre érvénytelen formát, de bárki leszármazhat belőle, így hozva létre új formákat:
            // A polimorfizmus szabályai továbbra is érvényesülnek
            Shapev2 shape5 = new Rectanglev2(2, 2);
            Console.WriteLine(shape5.CalculateArea());

            // Az abstract osztályt bármilyen taggal bővíthetjük (lásd: Shapev3)
            // Sőt konstruktora is lehet, viszont a konstruktor nem lehet abstract

            // Nem csak metódus, de tulajdonság is lehet abstract (hisz az lényegében csak két metódus) (lásd: Shapev4)

            // Sőt, leszármazott is lehet abstract, ha nem akarjuk az ősosztály adott tagját megvalósítani (lásd: Circlev3)

            //--------------------------------------------------

            // Az absztrakció valójában nem csak az abstract osztályok segítségével érhető el!
            // Gondoljuk végig, hogy az absztrakció legtisztább formája az, ha semmi másunk nincs csak egy tisztán abstract osztályunk, csak abstract metódusokkal, adatok nélkül

            // A C# sok más nyelv mellett egy külön kulcsszót vezetett be a tisztán abstract osztályok létrehozásához, az interface-t

            // Hozzunk létre egy Shape interface-t (lásd: IShape)
            // Természetesen ha egy abstract osztályból nem lehet példányt létrehozni, akkor egy interface-ből se lehet (hiszen az egy tisztán abstract osztály):
            //IShape shape6 = new IShape(); // Nem megy

            // Akkor mit csinálhatunk egy interface-el?
            // Megvalósíthatjuk! A polimorfizmus továbbra is működik!
            IShapev1 shape7 = new Circlev4();
            Console.WriteLine(shape7.CalculateArea());

            // Metódusok mellett tulajdonságot is tartalmazhatnak az interface-ek (lásd: IShapev2)

            // Interface-nek nem lehet konstruktora!

            // Keverhetjük is az abstract ősosztályt és az interface-t (lásd: IPrintable és Shapev5)

            // interface leszármazhat interface-ből (lásd: IPrintable és IGraphicsPrintable)

            //--------------------------------------------------

            // Interface vs. abstract osztály
            // Miért jó az egyik és miért a másik?

            // Eddig annyit tudunk, hogy az abstract osztály mindent tud amit egy interface!

            // Egy nagyon nagyon fontos különbség van!
            // Emlékezzünk vissza arra, hogy beszéltünk arról, hogy az osztályoknak egyetlen ősosztálya lehet!
            // Ezzel szemben egy osztály tetszőleges számú interface-t megvalósíthat! Sőt, egy interface tetszőleges számú interface-ből leszármazhat! (lásd: Circlev5)
            // Sőt, keverni is lehet (lásd: Circlev6)

            // Tehát egy osztály maximum egy osztályból származhat le és közben tetszőleges számú interface-t megvalósíthat

            // Mi a különbség még?
            // Az interface rugalmasabb, mivel csak egy adott viselkedést vár el! Például egy metódus átvesz egy IPrintable, akkor az az IPrintable lehet egy Animal vagy egy Shape vagy akármi
            // Csak viselkedést vár el, nincs adat! Ez egy sokkal enyhébb megkötés, azaz nem is lehet adatokat tönkretenni, rosszul kezelni stb.!

            //--------------------------------------------------

            // Pár tudnivaló:
            // struct nem származhat le se class-ból, se struct-ból, de interface-t megvalósíthat
            // tisztán statikus osztály (static class) nem származhat le semmiből és interface-t sem valósíthat meg

            //--------------------------------------------------

            // Mi van akkor, ha van egy Circle-öm és Shape-t szeretnék csinálni belőle?
            // Automatikusan megy = polimorfizmus:
            Shapev2 shape8 = new Circlev2(2);

            // Biztonságos? Mindig sikerül ez a konverzió?
            // Természetesen igen, hiszen egy leszármazott a polimorfizmus miatt bármikor használható ősosztályként

            // Mi is kényszeríthetjük:
            var shape9 = (Shapev2)new Circlev2(2);

            // Ezt hívjuk upcast-nak, hiszen felfelé kasztolunk az osztályhierarchiában

            // Ha van upcast, akkor van downcast is! Mi lehet ez?
            // Egy "ősosztály"-t (csak statikusan ősosztály, dinamikusan leszármazott) leszármazottá kasztolunk!
            Shapev2 shape10 = new Circlev2(2);
            Circlev2 circle1 = (Circlev2)shape10; // "ősosztályt" leszármazottá kasztolunk

            // Ez mindig működik?
            // Nem:
            Shapev2 shape11 = new Rectanglev2(2, 2);
            //Test(shape11); // Hiba
            // Ezt hívjuk downcast-nak, hiszen fentről lefelé kasztolunk az osztályhierarchiában

            // Oké, hiba keletkezik! Ezt kivédhetjük valahogyan?
            // Igen, többféle módon is!

            // Az as kulcsszó segítségével kasztolhatunk biztonságosan, ami azt jelenti, hogyha nem sikerül a kaszt, akkor null-t kapunk:
            Test2(shape11);

            // Az is kulcsszó segítségével bool-ként ellenőrizhetjük, hogy valami adott típusú-e! Ha igen, akkor biztonságosan kasztolhatjuk:
            Test3(shape11);

            // Sőt, újabban készíthetünk azonnal egy megfelelő típusú változót is:
            Test4(shape11);

            // Emellett újabban a switch is képes típust ellenőrizni:
            Test5(shape11);

            // FONTOS! A downcast, az as, az is és a switch nagyon kényelmes, de általában borzalmasan karbantartható kódot eredményez!
            // Gondoljunk arra, hogy mi van ha van egy új leszármazottunk! MINDEN switch-et frissíteni kell!
            // Így törkedjünk arra, hogy örökléssel, polimorfizmussal és absztrakcióval elkerüljük ezeket a helyzeteket!

            // Nem mindig kerülhető el és nem minden esetben érdemes elkerülni, de ezekről majd később!
        }

        static void Test1(Shapev2 shape)
        {
            var circle = (Circlev2)shape;
        }

        static void Test2(Shapev2 shape)
        {
            // null, ha nem sikerül
            var circle = shape as Circlev2;
        }

        static void Test3(Shapev2 shape)
        {
            if (shape is Circlev2)
            {
                var circle = (Circlev2)shape; // Biztos jó

                Console.WriteLine(circle.CalculateArea() * 2);
            }
            else
            {
                Console.WriteLine(shape.CalculateArea());
            }
        }

        static void Test4(Shapev2 shape)
        {
            // Azonnal készítünk egy változót, ha igaz
            if (shape is Circlev2 circle)
            {
                Console.WriteLine(circle.CalculateArea() * 2);
            }
            else
            {
                Console.WriteLine(shape.CalculateArea());
            }
        }

        static void Test5(Shapev2 shape)
        {
            switch (shape)
            {
                case Circlev2 circle:
                    Console.WriteLine(circle.CalculateArea() * 2);
                    break;
                case Rectanglev2 rectangle:
                    Console.WriteLine(rectangle.CalculateArea() * 3);
                    break;
                default:
                    Console.WriteLine(shape.CalculateArea());
                    break;
            }
        }
    }
}
