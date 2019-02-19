using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // x^3+3e^2x=0
        static void Main(string[] args)
        {
            //Получение отрезков
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            double d1 = -10;
            double d2 = 10;
            double dx = 0.1;
            x1 = d1;
            x2 = x1 + dx;
            y1 = F(x1);
            do
            {
                y2 = F(x1);
                if (y1 * y2 < 0)
                {
                    break;
                }
                x1 = x2;
                x2 = x1 + dx;
                y1 = y2;
            }
            while (x1 < d2);
            x2 = x1 - dx;
            Console.WriteLine("Отрезок");
            Console.WriteLine("[" + Math.Round(x2, 2) + ";" + Math.Round(x1, 2) + "]");
            double a = x2;
            double b = x1;
            //Метод бисекции
            double eps = 0.00000001;
            double c = 0;
            while (Math.Abs(a - b) > eps)
            {
                c = a + 0.5 * (b - a);
                if (F(a) * F(c) < 0)
                    b = c;
                else
                    a = c;
            }
            Console.WriteLine("Метод бисекции ");
            Console.WriteLine(Math.Round(c, 7));
            //Метод хорд
            a = x2;
            b = x1;
            c = 0;
            while (Math.Abs(a - b) > eps)
            {
                c = (a * F(b) - b * F(a)) / (F(b) - F(a));
                if (F(a) * F(c) < 0)
                    a = c;
                else
                    b = c;
            }
            Console.WriteLine("Метод хорд");
            Console.WriteLine(Math.Round(c, 7));
            //Метод касательных
            double y = 0, x;
            x = x1;
            while (Math.Abs(y - x) > eps)
            {
                y = x;
                x = x - F(x) / F1(x);
            }
            Console.WriteLine("Метод касательных");
            Console.WriteLine(Math.Round(x,7));
            //Комбинированный
            a = x2;
            b = x1;
            do
            {
                if (F(a) * F2(a) > 0)
                {
                    a += -F(a) / F1(a);
                    b = (a * F(b) - b * F(a)) / (F(b) - F(a));
                }
                else
                {
                    b += -F(b) / F1(b);
                    a = (a * F(b) - b * F(a)) / (F(b) - F(a));
                }
            }
            while (Math.Abs(a - b) > eps);
            Console.WriteLine("Комбинированный метод");
            Console.WriteLine(Math.Round((a+b)/2, 7));
            //Метод простых итераций
            a = x2;
            b = x1;
            double one = (a + b) / 2;
            double two;
            c = 0;
            if (Math.Abs(F1(a)) > Math.Abs(F1(b)))
            {
                c = -Math.Sign(F1(a)) / Math.Abs(F1(a));
            }
            else c = -Math.Sign(F1(b)) / Math.Abs(F1(b));
            two = one + c * F(one);
            while (Math.Abs(two - one) > eps)
            {
                one = two;
                two = one + c * F(one);
            }
            Console.WriteLine("Итерации");
            Console.WriteLine(Math.Round(two, 7));
            Console.ReadKey();
        }
        static double F(double x)
        {
            double F;
            F = Math.Pow(x,3) + 3 * Math.Exp(2 * x);
            return F;
        }
        static double F1(double x)
        {
            double F1;
            F1 = 3 * Math.Pow(x,2) + 6 * Math.Exp(2 * x);
            return F1;
        }
        static double F2(double x)
        {
            double F2;
            F2 = 6 * x + 12 * Math.Exp(2 * x);
            return F2;
        }
    }
}