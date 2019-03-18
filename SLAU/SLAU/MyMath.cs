using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class MyMath
    {
        public static void ShowMatrix(int n, double[,] a, double[] b, bool free)
        {
            if (free)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Отображение столбца свободных членов включено");
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(Convert.ToString(a[i, j]) + " ");
                    }
                    Console.Write(b[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Отображение столбца свободных членов отключено");
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(Convert.ToString(a[i, j]) + " ");
                    }
                    Console.WriteLine();
                }
            }
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
        public static void ShowMatrixDelta(int n, double[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Convert.ToString(a[i, j]) + " ");
                }
                Console.WriteLine();
            }
        }
        public static double Det(double[,] mat)
        {
            double res = 0;
            res = mat[0, 0] * mat[1, 1] * mat[2, 2] + mat[0, 1] * mat[1, 2] * mat[2, 0] + mat[1, 0] * mat[2, 1] * mat[0, 2] - mat[0, 2] * mat[1, 1] * mat[2, 0] - mat[0, 1] * mat[1, 0] * mat[2, 2] - mat[0, 0] * mat[1, 2] * mat[2, 1];
            return res;
        }
    }
}
