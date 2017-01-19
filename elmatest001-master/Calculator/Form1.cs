using Calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Калькулятор
        /// </summary>
        private Calc.Calc Calc { get; set; }

        private IEnumerable<string> OperationNames { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            Calc = new Calc.Calc(operations);

            OperationNames = Calc.GetOperationNames();

            // заполнить комбобокс
            FillCombobox();
        }

        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var func = comboBox1.Text;
            var parameters = new object[]
            {
                textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text
            }.Where(v => !string.IsNullOrWhiteSpace(v.ToString())).ToArray();
            lblResult.Text = $"{func}({string.Join(",", parameters)}) = {Calc.Execute(func, parameters)}{Environment.NewLine}" + lblResult.Text;
        }
    }
}
