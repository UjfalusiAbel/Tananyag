using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Képzeljük el, hogy egy vállalkozásnak készítünk egy alkalmazást, amiben nyomon követi a termelést
//Objektum-orientált programozás során mindig így próbálunk gondolkozni, próbálunk konkrét vagy akár absztraktabb dolgokat leírni 

namespace Objektum_orientalt_programozas.Bevezetes
{
    //A program egy eleme lesz a munkás, amit leírunk egy osztállyal
    //A "Worker" osztály egy tervrajz lesz ilyen típusú objektumok létrehozására
    //Az osztály változói a tulajdonságok, míg a függvények a hozzá tartozó metódusok lesznek

    /*Kis megjegyzés: az elnevezés jellemzően angol nyelven, a következőképpen történik (C# esetén szokás így -nyelvfüggő) (szerintem tartsuk be, mert jobb így, ha kitesszük majd a projektet): 
                    változók - első betű kicsi, minden újszóban kezdő nagy pl: maxValue
                    függvények - első betű nagy, minden új szóban kezdő nagy pl: CalculateMaxValue()
                    osztályok - ugyanaz, mint függvényeknél pl: CompanyWorker{}
                    interface-k - a név első betűje I, többi ugyanúgy, mint osztály vagy függvény pl: ICompanyWorker{}
    */
    public class Worker
    {
        //A munkásunk adatai
        public int age;
        public string firstName;
        public string lastName;
        public string companyName;
        public string role;
        public int salary;

        //Egy metódus, ami megnöveli munkásunk fizetését
        public void RaiseSalary(int amount)
        {
            salary+= amount;
        }

        //Egy másik, ami kiszámolja, mennyibe kerül évente munkásunk
        public int CalculateYearlyCost()
        {
            return salary*12;
        }

        //És egy utolsó kiíratni az adatait
        public void PrintData()
        {
            Console.WriteLine("A munkás neve: " + lastName + " " + firstName);
            Console.WriteLine(age + " éves");
            Console.WriteLine(companyName + "nél dolgozik mint " + role + " havi " + salary + " pénzért");
        }
    }

    //A változókat, függvényeket csoportosítottuk az osztály segítségével, ez az első pillér az objektum-orientált programozásban (encapsulation)
    //Ezentúl, mikor az objektum létrehozásra kerül, akkor ezen változók és függvények elérhetőek benne kívülről (már ha publikusak, ha nem akkor csak belülről érjük el), anélkül, hogy látnánk a beimplementálásukat. Ez az absztrakció
}