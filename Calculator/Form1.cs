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
using C = Calc;

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
        private C.Calc Calc { get; set; }

        private IEnumerable<string> OperationNames { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<C.IOperation>();
            #region Получение всех возм операций
            //Найти файлы dll в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
            //Загрузить их
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    //Найти реализацию интерфейса IOperation
                    if (interfaces.Contains(typeof(C.IOperation)))
                    {
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
            #endregion 

            Calc = new C.Calc(operations);
            OperationNames = Calc.GetOperationNames();
            //заполнить комбо-бокс
            FillCombobox();
        }

        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var activeoper = comboBox1.Text;
            var c = Convert.ToInt32(textBox5.Text);
            var parameters = new object[] { textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text };
            var result = Calc.Execute(activeoper, c, parameters);
            lblResult.Text = result.ToString();
        }
    }
}
