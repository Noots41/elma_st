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
            return (int)Execute("Sum", new object[] { x, y });
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

        public object Execute(string name, object[] args)
        {
            var opers = operations.Where(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            if (!opers.Any())
                return $"Operation \"{name}\" not found";
            //из всех операций выделяем только операции с кол-вом аргументов
            var opersWithCount = opers.OfType<IOperationCount>();


            var oper = opersWithCount.FirstOrDefault(o => o.Count == args.Count()) ?? opers.FirstOrDefault() as IOperation;
            
            if (oper == null)
            {
                return $"Operation \"{name}\" not found";
            }

            return oper.Execute(args);
        }

        public IEnumerable<string> GetOperationNames()
        {
            return operations.Select(o => o.Name);
        }
    }


    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);
    }

    public interface IOperationCount: IOperation
    {
        /// <summary>
        /// колличество аргументов в операции
        /// </summary>
        int Count { get; }
    }

    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }

        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);

            var y = Convert.ToInt32(args[1]);

            return x + y;
        }
    }

    public class DivOperation:IOperationCount
    {
        public string Name { get { return "Sum"; } }

        public object Execute(object[] args)
        {
            var x = Convert.ToInt32(args[0]);

            var y = Convert.ToInt32(args[1]);

            return x + y;
        }
        public int Count { get { return 2; } }
    }
}
