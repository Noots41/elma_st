using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            return (int)Execute("Sum", 2, new object[] { x, y });
        }

        public Calc(IEnumerable<IOperation> opers)
        {
            operations = opers;
        }

        public Calc(IOperation[] opers)
        {
            operations = opers;
        }

        private IEnumerable<IOperation> operations { get; set; }

        public object Execute(string name, int c, object[] args)
        {
            name = name.ToLower();
            var oper = operations.FirstOrDefault(o => (o.Name == name & o.C == c )); 
            return oper.Execute(args);
        }

        public IEnumerable<string> GetOperationNames()
        {
            return operations.Select(o => o.Name);
        }
    }
    public interface IOperation
    {
        int C { get; }
        string Name { get; }
        object Execute(object[] args);//обработчик
    }

    public class SumOperation : IOperation
    {
        public string Name { get { return "sum"; } }
        public int C { get { return 2; } }
        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);
            var y = Convert.ToInt32(args[1]);
            return x + y;
        }
    }

    public class TripleOperation : IOperation
    {
        public string Name { get { return "triple"; } }
        public int C { get { return 3; } }
        public object Execute(object[] args)
        {
            return 2 * Convert.ToInt32(args[2]) - Convert.ToInt32(args[1]) +
                Convert.ToInt32(args[0]);
        }
    }

    public class NullOperation : IOperation
    {
        public string Name { get { return "null"; } }
        public int C { get { return 0; } }
        public object Execute(object[] args)
        {
            return Execute();
        }
        private object Execute()
        { return 0; }
    }

    public class SingleOperation : IOperation
    {
        public string Name { get { return "single"; } }
        public int C { get { return 1; } }
        public object Execute(object[] args)
        {
            return (int)Math.Pow(Convert.ToInt32(args[0]), 2);
        }

    }

}
