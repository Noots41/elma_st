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
            var calc = new C.Calc(new Calc.IOperation[] { new C.SumOperation() });

            int result = calc.Sum(1, 2);
            int result2 = (int)calc.Execute("Sum", new object[] { 1, 2 });
            Console.WriteLine($"result = {result}");
            //Console.WriteLine(string.Format("result = {0}",result));
            Console.ReadKey();
        }
    }
}
