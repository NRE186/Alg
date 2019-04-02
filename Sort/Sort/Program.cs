using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Timer t = new Timer(TimerCallback, null, 0, 2000);

            arr = BubleSort.Sort(n);
            ArrWriter.WriteArray(arr);
            Console.ReadKey();
        }
        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}
