using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Matrix
    {
        public static void ShowMatrix(int n, double[,] a, double[] b)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Convert.ToString(a[i,j]) + " ");
                }
                Console.Write(b[i]);
                Console.WriteLine();
            }
        }
    }
}
