using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class PiOperation : IOperation
    {
        public string Name { get { return "pi"; } }

        public object Execute(object[] args)
        {
            return Math.PI;
        }
    }
}
