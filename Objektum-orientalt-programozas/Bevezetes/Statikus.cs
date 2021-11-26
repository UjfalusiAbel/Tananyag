using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Objektum_orientalt_programozas.Bevezetes
{
    public static class Statikus
    {
        public static int szam = 10;
        public static void Novel(int mennyiseg)
        {
            szam+=mennyiseg;
        }
    }
}