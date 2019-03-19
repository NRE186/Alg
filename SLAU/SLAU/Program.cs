﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAU
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = 3;
            double[,] a = { { 4.7 , 1.8 , -34 }, { -1.9, -36 , 2.7 }, { 33 , 4.5 , 1.5 } }; ;
            double[] b = { 38, 4, -16 };
            Console.WriteLine("Выберите метод решения системы уравнений. 1 - Метод Гаусса, 2 - второй метод");
            int val = int.Parse(Console.ReadLine());
            if (val == 1)
            {
                Methods.Iter(n, a, b);
            }
            else
            {
                Methods.Kramer(n,a,b);
            }
            Console.ReadKey();
        }
    }
}