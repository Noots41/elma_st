using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;

namespace ClassLibrary3
{
    public class Third : IOperation
    {
        public string Name { get { return "third"; } }
        public int C { get { return 2; } }
        public object Execute(object[] args)
        {
            return - Convert.ToInt32(args[1]) + Convert.ToInt32(args[0]);
        }
    }

    public class Example : IOperation
    {
        public string Name { get { return "example"; } }
        public int C { get { return 2; } }
        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[1]) * Convert.ToInt32(args[0]);
        }
    }
}
