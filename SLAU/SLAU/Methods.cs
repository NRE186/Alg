using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Methods
    {
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
        public static void Kramer(int n, double[,] a, double[] b)
        {
            int k = 0;
            double[,] delta = a;
            double[,] deltax1 = new double[n,n];
            double[,] deltax2 = new double[n, n]; 
            double[,] deltax3 = new double[n, n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 && j == 0) || (i == 1 && j == 0) || (i == 2 && j == 0))
                    {
                        deltax1[i, j] = b[k];
                        k++;
                    }
                    else
                    {
                        deltax1[i, j] = a[i, j];
                    }
                }
            }
            k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 && j == 1) || (i == 1 && j == 1) || (i == 2 && j == 1))
                    {
                        deltax2[i, j] = b[k];
                        k++;
                    }
                    else
                    {
                        deltax2[i, j] = a[i, j];
                    }
                }
            }
            k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 && j == 2) || (i == 1 && j == 2) || (i == 2 && j == 2))
                    {
                        deltax3[i, j] = b[k];
                        k++;
                    }
                    else
                    {
                        deltax3[i, j] = a[i, j];
                    }
                }
            }
            MyMath.ShowMatrixDelta(n, delta);
            double[] x = new double[n];
            x[0] = (MyMath.Det(deltax1) / MyMath.Det(delta));
            x[1] = (MyMath.Det(deltax2) / MyMath.Det(delta));
            x[2] = (MyMath.Det(deltax3) / MyMath.Det(delta));
            Console.WriteLine(x[0] + " " + x[1] + " " + x[2]);
        }
    }
}
