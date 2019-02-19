using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Инициализация переменных
            int n = 10;
            int[] arr = new int[n];

            arr = BubleSort.Sort(n);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
