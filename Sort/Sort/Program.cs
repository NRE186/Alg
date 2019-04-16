using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int n = 75;
            SortMethods sort = new SortMethods
            {
                N = n
            };
            sort.TimSort();
            sort.SmoothSort();
            Thread.Sleep(1000);
            Process.Start(Environment.CurrentDirectory + @"\Отчёт\report.txt");
        }
    }
}
