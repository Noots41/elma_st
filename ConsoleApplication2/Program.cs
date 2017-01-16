using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Calc;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cals = new C.Calc();
            int result = cals.Sum(1, 2);
            Console.WriteLine($"result = {result}");
            //Console.WriteLine(string.Format("result = {0}",result));
            Console.ReadKey();
        }
    }
}
