using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class BubleSort:Randomizer
    {
        public static int[] Sort(int n)
        {
            int[] sort = RandomArray(n);
            for (int i = 0; i < sort.Length; i++)
                for (int j = 0; j < sort.Length - 1; j++)
                {
                    if (sort[j] > sort[j + 1])
                    {
                        int temp = sort[j];
                        sort[j] = sort[j + 1];
                        sort[j + 1] = temp;
                    }
                }
            return sort;
        }
    }
}
