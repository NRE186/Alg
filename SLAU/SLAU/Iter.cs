using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Iter
    {
        public static void IterMethod(int n, double[,] a, double[] b)
        {
            Console.WriteLine("Метод простых итераций");
            //Инициализация переменных
            double d1 = 0, d2 = 0, d3 = 0;
            double eps = 0.000000000000000000001;
            int c = 0;
            int k = 100;
            double[,] x = new double[k, n];
            x[0, 0] = 0;
            x[0, 1] = 0;
            x[0, 2] = 0;
            double[,] tmp = new double[n,n];
            while (!(Math.Abs(a[0, 0]) > Math.Abs(a[0, 1]) + Math.Abs(a[0, 2]) && Math.Abs(a[1, 1]) > Math.Abs(a[1, 0]) + Math.Abs(a[1, 2]) && Math.Abs(a[2, 2]) > Math.Abs(a[2, 0]) + Math.Abs(a[2, 1])))
            {
                for (int j = 0; j < n; j++)
                {
                    tmp[0, j] = a[0, j];
                    a[0, j] = a[2, j];
                    a[2, j] = tmp[0, j];
                }
            }
            while (Max(d1,d2,d3) < eps)
            {
                x[c + 1, 0] = (b[0] - a[0, 1] * x[c, 1] - a[0, 2] * x[c, 2]) / a[0, 0];
                x[c + 1, 1] = (b[1] - a[1, 0] * x[c, 0] - a[1, 2] * x[c, 2]) / a[1, 1];
                x[c + 1, 2] = (b[2] - a[2, 1] * x[c, 0] - a[2, 1] * x[c, 1]) / a[2, 2];

                d1 = Math.Abs(x[c + 1, 0] - x[c, 0]);
                d2 = Math.Abs(x[c + 1, 1] - x[c, 1]);
                d3 = Math.Abs(x[c + 1, 2] - x[c, 2]);
                c++;
            }
            Console.WriteLine(-d3);
            Console.WriteLine(-d2);
            Console.WriteLine(-d1);
        }

        public static double Max(double d1, double d2, double d3)
        {
            if (d1 > d2)
            {
                if (d1 > d3)
                {
                    return d1;
                }
                else return d3;
            }
            else
            {
                if (d2 > d3)
                {
                    return d2;
                }
                else return d3;
            }
        }
    }
}
