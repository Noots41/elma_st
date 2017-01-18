using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class PiOperation:IOperation
    {
        public string Name { get { return "pi"; } }
        public int C { get { return 0; } }
        public object Execute(object[] args)
        {
            return (int)Math.PI;
        }
    }
}
