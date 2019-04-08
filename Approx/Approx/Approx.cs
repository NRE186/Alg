using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approx
{
    class Approx
    {
        public static void Linear(int n, decimal[]x, decimal[] y)
        {
            decimal[] xy = new decimal[n];
            decimal[] xx = new decimal[n];
            decimal sumx = 0, sumy = 0, sumxy = 0, sumxx = 0;
            decimal a = 0, b = 0;
            //Находим суммы и прозведения
            for (int i = 0; i < n; i++)
            {
                sumx += x[i];
                sumy += y[i];
                sumxy += x[i] * y[i];
                sumxx += x[i] * x[i];
            }
            //Находим коэффициенты A и B 
            a = (n * sumxy - sumx * sumy) / (n * sumxx - sumx * sumx);
            b = (sumy - a * sumx) / (n);
            Console.WriteLine("Линейная аппроксимация");
            Console.WriteLine("Полученные коэффициенты: A -> " + a + " B -> " + b);
            Console.WriteLine("y = " + a + "x + " + b);
        }
        public static void Square(int n, decimal[] x, decimal[] y)
        {
            decimal sumx = 0, sumy = 0, sumxy = 0, sumx2 = 0, sumx3 = 0, sumx4 = 0, sumx2y = 0;
            //Находим суммы и прозведения
            for (int i = 0; i < n; i++)
            {
                sumx += x[i];
                sumy += y[i];
                sumxy += x[i] * y[i];
                sumx2 += x[i] * x[i];
                sumx2y += x[i] * x[i] * y[i];
                sumx3 += x[i] * x[i] * x[i];
                sumx4 += x[i] * x[i] * x[i] * x[i];
            }
            decimal[,] k = new decimal[n,n];
            decimal[] f = new decimal[n];
            f[0] = sumy;
            f[1] = sumxy;
            f[2] = sumx2y;
            k[0, 0] = sumx2;
            k[0, 1] = sumx;
            k[0, 2] = n;
            k[1, 0] = sumx3;
            k[1, 1] = sumx2;
            k[1, 2] = sumx;
            k[2, 0] = sumx4;
            k[2, 1] = sumx3;
            k[2, 2] = sumx2;
            //Находим коэффициенты A и B
            MyMath.Kramer(n, k, f);
        }
        public static void Log(int n, decimal[] x, decimal[] y)
        {
            double[] xd = new double[n];
            double[] yd = new double[n];
            for (int i = 0; i < n; i++)
            {
                xd[i] = (double)x[i];
                yd[i] = (double)y[i];
            }
            decimal sumyLnx = 0, sumLnx = 0, sumy = 0, sumLn2x = 0;
            decimal a = 0, b = 0;
            //Находим суммы и прозведения
            for (int i = 0; i < n; i++)
            {
                sumy += y[i];
                sumyLnx += y[i] * (decimal)Math.Log(xd[i]);
                sumLnx += (decimal)Math.Log(xd[i]);
                sumLn2x += (decimal)Math.Log(xd[i]) * (decimal)Math.Log(xd[i]);
            }
            //Находим коэффициенты A и B
            b = (n * sumyLnx - sumLnx * sumy) / (n * sumLn2x - sumLnx * sumLnx);
            a = 1 / n * sumy - b / n * sumLnx; 
            Console.WriteLine("Логарифмическая аппроксимация");
            Console.WriteLine("Полученные коэффициенты: A -> " + Math.Round(a,6) + " B -> " + Math.Round(b, 6));
            Console.WriteLine("y = " + Math.Round(a, 6) + " + " + Math.Round(b, 6) + "lnx");
        }
        public static void Exp(int n, decimal[] x, decimal[] y)
        {
            double[] xd = new double[n];
            double[] yd = new double[n];
            for (int i = 0; i < n; i++)
            {
                xd[i] = (double)x[i];
                yd[i] = (double)y[i];
            }
            decimal sumx = 0, sumxx = 0, sumLny = 0, sumxLny = 0;
            decimal a = 0, b = 0;
            //Находим суммы и прозведения
            for (int i = 0; i < n; i++)
            {
                sumx += x[i];
                sumxx += x[i] * x[i];
                sumLny += (decimal)Math.Log(yd[i]);
                sumxLny += x[i] * (decimal)Math.Log(yd[i]);
            }
            //Находим коэффициенты A и B
            b = (n * sumxLny - sumx * sumLny) / (n * sumxx - sumx * sumx);
            a = 1 / n * sumLny - b / n * sumx;
            Console.WriteLine("Экспонинциальная аппроксимация");
            Console.WriteLine("Полученные коэффициенты: A -> " + Math.Round(a, 6) + " B -> " + Math.Round(b, 6));
            Console.WriteLine("y = e^" + Math.Round(a, 6) + " + " + Math.Round(b, 6) + "x");
        }
    }
}
