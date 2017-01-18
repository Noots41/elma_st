using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Thema : IOperation
    {
        public string Name { get { return "th"; } }
        public int C { get { return 0; } }
        public object Execute(object[] args)
        {
            return 8;
        }
    }

    public class Example : IOperation
    {
        public string Name { get { return "example"; } }
        public int C { get { return 1; } }
        public object Execute(object[] args)
        {
            return Convert.ToInt32(args[0]);
        }
    }

}
