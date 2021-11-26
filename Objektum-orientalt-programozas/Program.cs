using System;
using Objektum_orientalt_programozas.Bevezetes;

namespace Objektum_orientalt_programozas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Létrehozunk egy Worker típusú objektumot
            // a new szó segít ebben, ami meghívja a Worker osztály constructor-ját 
            //constructor: függvény, ami létrehozza az adott típust, van alapból minden osztály esetén, de fogunk sajátokat is írni
            Worker worker1 = new Worker();
            Worker munkas2 = new Worker();

            worker1.age = 30;
            worker1.firstName = "János";
            worker1.lastName = "Kis";
            worker1.companyName = "Valami vagány cégnév";
            worker1.role = "autószerelő";
            worker1.salary = 1000;
            worker1.PrintData();
            worker1.RaiseSalary(500);
            worker1.PrintData();

            munkas2.salary = 2000;
            int koltseg =  munkas2.CalculateYearlyCost();

            //Mivel írtunk egy saját constructort, ami feltölti értékkel, ezért nem kell az előző példához hasonlóan inicializáljuk az értékeket
            Company newCompany = new Company("Egy jó cég", "Szép hely", 100, 20000000,14000000);
            newCompany.PrintData();

            //Constructorok sorban meghívva. Ugyanilyen függvényekben is
            Point3D a = new Point3D();
            Point3D b = new Point3D(1,2,3);
            Point3D c = new Point3D(3f,2f,6f);
            Point3D d = new Point3D(2f,5f);

            //Nem egy Point3D típusú változóból, direkt a Point3D-ből hívom meg, mert static. Ha kipróbálod, a változói nem is tartalmazzák
            float distance = Point3D.Distance(c,d);
            Console.WriteLine("A két pont távolsága: " + distance);
            Console.ReadKey();

            Statikus.szam = 16;
            Munkas valtozo = new Munkas();
        }

        static void Fuggveny(Ember valtozo)
        {

        }
    }
}
