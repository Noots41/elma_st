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
            return (int)args[0] + (int)args[1];//нужна проверка на кол-во элементов
        }
    }
}
