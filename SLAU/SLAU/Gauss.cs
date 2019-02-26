using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Gauss
    {
        public static void GaussMethod(int n, double[,] a, double [] b)
        {
            Console.WriteLine("Метод Гаусса");
            //Инициализация переменных
            double s = 0;
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = 0;
            Matrix.ShowMatrix(n, a, b, false);
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
            Matrix.ShowMatrix(n, a, b, false);
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
    }
}
