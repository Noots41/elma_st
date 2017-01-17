using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Thema:IOperation
    {
        public string Name { get { return "th"; } }
        public object Execute(object[] args)
        {
            return "Thema";
        }
    }
}
