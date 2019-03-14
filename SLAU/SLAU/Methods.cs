using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Methods
    {
        public static void Gauss(int n, double[,] a, double[] b)
        {
            Console.WriteLine("Метод Гаусса");
            double s = 0;
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = 0;
            MyMath.ShowMatrix(n, a, b, false);
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }
            MyMath.ShowMatrix(n, a, b, false);
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + a[k, j] * x[j];
                x[k] = (b[k] - s) / a[k, k];
            }
            Console.WriteLine("Система имеет следующие корни");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("x" + (i + 1) + " = " + x[i]);
            }
        }
        public static void Iter(int n, double[,] a, double[] b)
        {
            Console.WriteLine("Метод простых итераций");
            double d1 = 0, d2 = 0, d3 = 0;
            double eps = 0.00000000001;
            int c = 0;
            int k = 100;
            double[] x = new double[n];
            double[,] tmp = new double[n, n];
            //Замена 1 и 3 строк матрицы между собой
            while (!(Math.Abs(a[0, 0]) > Math.Abs(a[0, 1]) + Math.Abs(a[0, 2]) && Math.Abs(a[1, 1]) > Math.Abs(a[1, 0]) + Math.Abs(a[1, 2]) && Math.Abs(a[2, 2]) > Math.Abs(a[2, 0]) + Math.Abs(a[2, 1])))
            {
                for (int j = 0; j < n; j++)
                {
                    tmp[0, j] = a[0, j];
                    a[0, j] = a[2, j];
                    a[2, j] = tmp[0, j];
                }
            }
            MyMath.ShowMatrix(n,a,b,true);

        }
    }
}
