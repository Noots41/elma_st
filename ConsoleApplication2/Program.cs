using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using C = Calc;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args) //calc.exe "sum" "1" "2"
        {
            #region
            //try
            //{
            //    var calc = new C.Calc(new C.IOperation[] { new C.SumOperation() });
            //    //int result = calc.Sum(1, 2);
            //    int result = (int)calc.Execute("Sum", new object[] { 1 });
            //    Console.WriteLine($"result = {result}");
            //    //Console.WriteLine(string.Format("result = {0}",result));
            //    Console.ReadKey();
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught - {0}", e.Message);
            //    Console.ReadKey();
            //} 
            #endregion

            if (!args.Any())
            {
                Console.WriteLine("calc.exe \"sum\" \"1\" \"2\"");
                Console.ReadKey();
                return;
            }

            var operations = new List<C.IOperation>();

            #region 
            //Найти файлы dll exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //Загрузить их
            foreach(var file in files)
            {
                //Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();



                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    //Найти реализацию интерфейса IOperation
                    if (interfaces.Contains(typeof(C.IOperation)))
                    {
                        //Console.WriteLine(type.Name);
                        //создаем экземпляр класса и приводим его к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as C.IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }

                }
                //Создать экземпляр класса
                //Все эти экземпляры передаем в calc
            }
            #endregion Получение всех возм операций

            var calc = new C.Calc(operations);

            var activeoper = args[0];
            var parameters = args.Skip(1).ToArray();//Select(a => (object)a).ToArray();

            var result = calc.Execute(activeoper, parameters);
            Console.WriteLine($"result = {result}");

            Console.ReadKey();
        }
    }
}
