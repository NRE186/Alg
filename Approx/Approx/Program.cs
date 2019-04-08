using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approx
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] X = { 7.4m, 7.8m, 8.2m, 8.6m, 9m};
            decimal[] Y = { 9.01m, 6.04m, 4.24m, 3.2m, 3.01m};
            int N = X.Length;
            Approx.Linear(N,X,Y);
            Approx.Square(N, X, Y);
            Approx.Log(N, X, Y);
            Approx.Exp(N, X, Y);

            Console.ReadLine();
        }
    }
}
