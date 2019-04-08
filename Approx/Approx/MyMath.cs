using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approx
{
    class MyMath
    {
        public static void Kramer(int n, decimal[,] a, decimal[] b)
        {
            int k = 0;
            decimal[,] delta = a;
            decimal[,] deltax1 = new decimal[n, n];
            decimal[,] deltax2 = new decimal[n, n];
            decimal[,] deltax3 = new decimal[n, n];
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
            decimal[] x = new decimal[n];
            x[0] = (Det(deltax1) / Det(delta));
            x[1] = (Det(deltax2) / Det(delta));
            x[2] = (Det(deltax3) / Det(delta));
            Console.WriteLine("Квадратичная аппроксимация");
            Console.WriteLine("Полученные коэффициенты: A -> " + Math.Round(x[0],5) + " B -> " + Math.Round(x[1], 5) + " C -> " + Math.Round(x[2], 5));
            Console.WriteLine("y = " + Math.Round(x[0], 5) + "x^2 + " + Math.Round(x[1], 5) + "x + " + Math.Round(x[2], 5));
        }
        public static decimal Det(decimal[,] mat)
        {
            decimal res = 0;
            res = mat[0, 0] * mat[1, 1] * mat[2, 2] + mat[0, 1] * mat[1, 2] * mat[2, 0] + mat[1, 0] * mat[2, 1] * mat[0, 2] - mat[0, 2] * mat[1, 1] * mat[2, 0] - mat[0, 1] * mat[1, 0] * mat[2, 2] - mat[0, 0] * mat[1, 2] * mat[2, 1];
            return res;
        }
    }
}
