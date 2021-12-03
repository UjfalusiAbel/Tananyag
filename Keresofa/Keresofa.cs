using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keresofa
{
    public class Keresofa
    {
        nod gyoker = new nod();

        public void beszuras(int x){
            gyoker = beszurasrekurziv(x, gyoker);
        }

        public void kiir(){
            kiirrekurziv(gyoker);
        }

        private void kiirrekurziv(nod gyokerrekurziv){
            if (gyokerrekurziv != null){
                kiirrekurziv(gyokerrekurziv.bal);
                Console.WriteLine (gyokerrekurziv.ertek);
                kiirrekurziv(gyokerrekurziv.jobb);
            }
        }
        private nod beszurasrekurziv(int x, nod gyoker){
            if (gyoker == null){
                nod uj = new nod();
                uj.ertek = x;
                return uj;
            }
            if (x < gyoker.ertek){
                gyoker.bal = beszurasrekurziv( x, gyoker.bal);
            }
            if (x > gyoker.ertek){
                gyoker.jobb = beszurasrekurziv( x, gyoker.jobb);
            }
            return gyoker;

        }

        private nod kereserekurziv(int x, nod gyoker1){
            if (gyoker1 == null || gyoker1.ertek == x){
                return gyoker1;
            }
            if (x < gyoker1.ertek){
                return  kereserekurziv( x, gyoker1.bal);
            }
                return kereserekurziv( x, gyoker1.jobb);
            }

        public bool keres (int x){
            nod gyoker1 = kereserekurziv(x, gyoker);
            if(gyoker1!=null)
            {
                return true;
            }
            return false;

        }

    }
}