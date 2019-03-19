using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 2 * Math.PI;
            double step = 0.000001;
            int k = 0;
            Console.WriteLine("Метод Симпсона");
            double S = 0, x1, h;
            //отрезок [a, b] разобьем на N частей
            h = (b - a) / 10000;
            x1 = a + h;
            while (x1 < b)
            {
                S = S + 4 * F(x1);
                x1 = x1 + h;
                //проверяем не вышло ли значение x за пределы полуинтервала [a, b)
                if (x1 >= b) break;
                S = S + 2 * F(x1);
                x1 = x1 + h;
            }
            S = (h / 3) * (S + F(a) + F(b));
            Console.WriteLine(Math.Round(S, 4));


            double result1 = 0, result3 = 0;
            k = 0;
            for (double x = a; x < b; x += step)
            {
                /* Метод прямоугольников
                 * эта область разбивается на несколько прямоугольников(зависит от шага) и считается сумма их площадей: 
                 * как ширина * высота  ширина - это шаг, высота левая высота(а, а+h, a+2h...b-h) высота = f(x) - подинтегральная функция 
                 * 
                 * Метод трапеций
                 * область разбивается на трапеции. площадь: (левая_высота+правая_высота)*шаг/2              
                 * 
                 */

                result1 += F(x) * step;          //левых прямоугольников
                result3 += step * (F(x) + F(x + step)) / 2;   //трапеций
                k++;
            }
            Console.WriteLine(Math.Round(result1,4) + " " + Math.Round(result3,4) + " " + k);
            Console.ReadLine();
            
            double F(double x)
            {
                return x * Math.Sin(x / 2);
            }
        }
    }
}
