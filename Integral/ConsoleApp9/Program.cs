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
            double d, y, res = 0;
            d = 0.0001;
            for (double x = 0; x <= 2 * Math.PI; x += d)
            {
                y = F(x);// подинтегральная функция
                res += y * d; // Элементарное приращение
            }
            Console.WriteLine(Math.Round(res, 4));
            Console.ReadLine();
            double F(double x)
            {
                return x * Math.Sin(x / 2);
            }
        }
    }
}
