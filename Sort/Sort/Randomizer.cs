using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Randomizer
    {
        public static int[] RandomArray(int n)
        {
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
                a[i] = rand.Next(0,99);
            return a;
        }
    }
}
