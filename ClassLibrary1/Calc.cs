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

        public Calc(IOperation[] opers)
        {
            operations = opers;
        }

        private IOperation[] operations { get; set; }

        public object Execute(string name, object[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            return oper.Execute(args);
        }
    }
    public interface IOperation
    {
        string Name { get; }
        object Execute(object[] args);//обработчик
    }

    public class SumOperation : IOperation
    {
        public string Name { get { return "Sum"; } }
        public object Execute(object[] args)
        {
            if (args.Length < 2)
                throw new IndexOutOfRangeException("Необходимо 2 аргумента");
            return (int)args[0] + (int)args[1];
        }
    }

    public class TripleOperation : IOperation
    {
        public string Name { get { return "Triple"; } }
        public object Execute(object[] args)
        {
            if (args.Length < 3)
                throw new IndexOutOfRangeException("Необходимо 3 аргумента");
            return 2*(int)args[2] - (int)args[1] + (int)args[0];
        }
    }

    public class NullOperation : IOperation
    {
        public string Name { get { return "Null"; } }
        public object Execute(object[] args)
        {
            return Execute();
        }
        private object Execute()
        { return 0; }
    }

    public class SingleOperation : IOperation
    {
        public string Name { get { return "Single"; } }
        public object Execute(object[] args)
        {
            if (args.Length < 1)
                throw new IndexOutOfRangeException("Необходим 1 аргумент"); //Exception("Необходим 1 аргумент");
            return (int)Math.Pow((int)args[0], 2);
        }

    }

}
