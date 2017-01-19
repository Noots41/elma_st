using Calc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine(" calc.exe \"sum\" \"1\" \"2\"");
                Console.ReadKey();
                return;
            }

            var operations = new List<IOperation>();

            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            // загрузить их
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    // найти реализацюию интерфейса IOperation
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //Console.WriteLine(type.Name);
                        // создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }
            #endregion

            // calc.exe "sum" "1" "2"

            var calc = new Calc.Calc(operations);

            var activeoper = args[0];

            var parameters = args.Skip(1).ToArray();

            var result = calc.Execute(activeoper, parameters);

            Console.WriteLine($"result = {result}");

            Console.ReadKey();
        }
    }
}
