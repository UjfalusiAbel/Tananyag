using System;

namespace Keresofa
{
    class Program
    {
        static void Main(string[] args)
        {
            Keresofa ertek = new Keresofa();
            ertek.beszuras(50);
            ertek.beszuras(30);
            ertek.beszuras(20);
            ertek.beszuras(40);
            ertek.beszuras(70);
            ertek.beszuras(60);
            ertek.beszuras(80);

            ertek.kiir();
            bool keres = ertek.keres(36);
            Console.WriteLine(keres);
        }
    }
}
