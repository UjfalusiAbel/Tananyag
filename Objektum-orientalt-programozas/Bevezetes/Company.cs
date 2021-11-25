using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Ez egy egyszerű példa lesz arra, hogy mi is az a constructor s hogyan használjuk

namespace Objektum_orientalt_programozas.Bevezetes
{
    //Egy constructor egy függvény, melynek nincs neve és az osztály típusával deklaráljuk. A constructorban tudunk bevinni paramétereket is
    //A constructor automatikusan meghívásra kerül objektum létrehozásakor
    //A constructor kötelezően public
    //Legtöbbször inicializálás céljából használunk constructorokat, tehát az objektumot a létrehozásakor feltöltsük adatokkal a constructor paraméterein keresztül.
    public class Company
    {
        string name;
        string location;
        int numberOfEmployee;
        int income;
        int outgoing;
        int profit;
        
        public Company(string name, string location, int numberOfEmployee, int income, int outgoing)
        {
            //A this arra utal, hogy az osztályé a változó és nem pedig a függvény paraméteréhez tartozik. Azonos név esetén kell
            this.name = name;
            this.location = location;
            this.numberOfEmployee = numberOfEmployee;
            this.income = income;
            this.outgoing = outgoing;
            profit = income - outgoing;
        }

        public void PrintData()
        {
            Console.WriteLine("Cégnév " + name);
            Console.WriteLine("Székhely " + location);
            Console.WriteLine("Munkások száma " + numberOfEmployee);
            Console.WriteLine("Bevétel " + income);
            Console.WriteLine("Kiadás " + outgoing);
            Console.WriteLine("Profit " + profit);
        }
    }
}