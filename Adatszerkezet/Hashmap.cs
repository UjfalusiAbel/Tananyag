using System;
using System.Collections.Generic;

namespace Adatszerkezet
{
    public class Hashmap
    {
        int[] tomb = new int[100]();
        List<int> lista = new List<int>();
        Dictionary<string, int> gyumolcsok = new Dictionary<string, int>();
        Stack<int> verem = new Stack<int>();
        
        public void Start()
        {
            gyumolcsok.Add("korte", 10);
            gyumolcsok["korte"] *= 2;
            int sum =0;
            foreach(var gyumolcs in gyumolcsok)
            {
                sum+=gyumolcs.Value;
            }
        }
    }
}