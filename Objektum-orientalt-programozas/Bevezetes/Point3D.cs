using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Objektum_orientalt_programozas.Bevezetes
{
    //Ez a 3 dimenziós pontot leíró osztály a polimorfizmust fogja bemutatni
    //Ez nem más, mint függvények túltöltése (method overload). Azonos nevű, de más paraméterű függvények. A példa szerintem mutatja. Leggyakrabban constructorokban jelenik meg
    //Egy másik koncepció is itt lesz -- static kezelés
    //Ami static az nem tervrajzként fog megjelenni, hanem létrejön a memóriában. static lehet egy osztály, egy függvény vagy egy változó is. 
    //Itt egy static függvényre lesz példa, ez létezni fog akkor is, ha nem hozunk létre egy Point3D változót, nemcsak egy tervrajz (és amúgy nem része egy Point3D típusú változónak)
    //Egy másik: static osztályból nem képezhető változó, mindössze meghívhatók bárhol függvényei, de nincs és nem lehet constructorja
    public class Point3D
    {
        float x;
        float y;
        float z;

        //A 4 constructor közül az kerül meghívásra, amelyiknek megfelelő paramétereket írjuk
        public Point3D(){}
        public Point3D(int x, int y, int z)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.z = (float)z;
        }
        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point3D(float x, float z)
        {
            this.x = x;
            y = 0f;
            this.z = z;
        }

        //Ez lefoglal egy helyet a memóriában, mint pl egy sima C++-ban tanult függvény. 
        //Nem az osztály típúsú változóból, direkt az osztályból hívod meg.
        //Hasznos, ha nem kell elérd az osztály semmilyen változóját benne s memóriát spórol, mert nem hozza létre minden változóban a függvényt
        //Static változók esetén segít központilag megosztani adatokat
        public static float Distance(Point3D a, Point3D b)
        {
            float xComponent = (a.x - b.x)*(a.x - b.x);
            float yComponent = (a.y - b.y)*(a.y - b.y);
            float zComponent = (a.z - b.z)*(a.z - b.z);
            double sum = (double)(xComponent + yComponent +zComponent);
            return (float)Math.Sqrt(sum);
        }
    }
}