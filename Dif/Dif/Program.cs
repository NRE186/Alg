using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dif
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0; double b = 1; double h = 0.1; double c0 = 0; double c1 = 0; double k1 = 0; double k2 = 0; double k3 = 0; double k4 = 0;
            double n = (b - a) / h;
            double[] X1 = new double[(int)n + 1];
            double[] Y1 = new double[(int)n + 1];
            double[] X2 = new double[(int)n + 1];
            double[] Y2 = new double[(int)n + 1];
            double[] X3 = new double[(int)n + 1];
            double[] Y3 = new double[(int)n + 1];
            X1[0] = a; Y1[0] = 1;
            X2[0] = a; Y2[0] = 1;
            X3[0] = a; Y3[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                //Метод Эйлера
                X1[i] = a + i * h;
                Y1[i] = Y1[i - 1] + h * F(X1[i - 1], Y1[i - 1]);
                //Модифицированный метод Эйлера
                c0 = F(X2[i - 1] ,Y2[i - 1]);
                c1 = F(X2[i - 1] + h/2, Y2[i - 1] + h/2*c0);
                X2[i] = X2[i - 1] + h;
                Y2[i] = Y2[i - 1] + c1 * h;
                //Рунге-Кутты
                k1 = F(X3[i - 1], Y3[i - 1]);
                X3[i] = X3[i - 1] + h / 2;
                k2 = F(X3[i - 1], Y3[i - 1] + h / 2 * k1);
                k3 = F(X3[i - 1], Y3[i - 1] + h / 2 * k2);
                X3[i] = X3[i - 1] + h;
                k4 = F(X3[i - 1], Y3[i - 1] + h / 2 * k3);
                Y3[i] = Y3[i - 1] + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
            }
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("X1[" + i + "]=" + X1[i] + " ");
            }
            for (int i = 0; i <= n; i++)
            {
                Console.CursorTop = i;
                Console.CursorLeft = 10;
                Console.WriteLine("Y1[" + i + "]=" + Y1[i] + " ");
            }
            Console.WriteLine();
            Console.CursorTop = 12;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("X2[" + i + "]=" + X2[i] + " ");
            }
            int x = 12;
            for (int i = 0; i <= n; i++)
            {
                Console.CursorTop = x;
                Console.CursorLeft = 10;
                Console.WriteLine("Y2[" + i + "]=" + Y2[i] + " ");
                x++;
            }
            Console.WriteLine();
            Console.CursorTop = 24;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("X3[" + i + "]=" + X3[i] + " ");
            }
            x = 24;
            for (int i = 0; i <= n; i++)
            {
                Console.CursorTop = x;
                Console.CursorLeft = 15;
                Console.WriteLine("Y3[" + i + "]=" + Y3[i] + " ");
                x++;
            }

            Console.ReadLine();
            
            double F(double X, double Y)
            {
                return Math.Pow(X,2) - 2 * Y;
            }
        }
    }
}
