using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Calc
{
    public class Calc
    {
        private static Calc calc;

        //public int Sum(int x, int y)
        //{
        //    return (int)Execute("Sum", new object[] { x, y });
        //}

        //public Calc(IEnumerable<IOperation> opers)
        //{
        //    operations = opers;
        //}

        //public Calc(IOperation[] opers)
        //{
        //    operations = opers;
        //}
        
        public Calc()
        {
            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.dll");

            //загрузить их
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
                {
                    // найти реализацюию интерфейса IOperation
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            if (operations == null)
                                operations = oper as IEnumerable<IOperation>;
                            else
                                operations = operations.Union(oper as IEnumerable<IOperation>);//.Add(oper);
                        }
                    }
                }
            }
            #endregion
        }

        public IEnumerable<IOperation> operations
        {
            get; set;
        }

        public static Calc getCalc()
        {
            if (calc == null)
                calc = new Calc();
            return calc;
        }



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
            if (calc == null)
                calc = new Calc();
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
