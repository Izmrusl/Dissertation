using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.MidpointRounding.AwayFromZero;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(textBox3.Text);
            int k = n;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            for (int i = 0; i <= k; i++)
            {
                dataGridView2.Columns.Add(i.ToString(), i.ToString());

            }

            for (int i = 1; i <= n; i++)
            {

                dataGridView2.Rows.Add(i.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int n = Int32.Parse(textBox1.Text);
            int k = n;           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            for (int i = 0; i <= k; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView2.Columns.Add(i.ToString(), i.ToString());
                dataGridView3.Columns.Add(i.ToString(), i.ToString());
                dataGridView4.Columns.Add(i.ToString(), i.ToString());

            }

            for (int i = 1; i <= n; i++)
            {               
                dataGridView1.Rows.Add(i.ToString());
                dataGridView2.Rows.Add(i.ToString());
                dataGridView3.Rows.Add(i.ToString());
                dataGridView4.Rows.Add(i.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.ColumnCount = 1; // число столбцов
            string textFromFile;
            using (FileStream fstream = File.OpenRead("1.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
                

            }
            double[,] number = new double[10, 10]; // задаем двойной массив, границы массива
            {
                
                int i = 0;
                int k = 0;
                string temp = "";
                foreach (char sym in textFromFile)
                //for (int ind = 1; ind < textFromFile.Length; ind++)
                {
                    
                    //MessageBox.Show(sym.ToString());
                    //if (textFromFile[ind].Equals(" "))
                    if (sym != 32)
                    {
                        temp = temp + sym;
                        //MessageBox.Show(temp);
                    }
                    else if (temp != "")
                    {
                        number[k, i] = Convert.ToDouble(temp);
                        i++;
                        temp = "";
                    }
                    if (i == dataGridView1.Columns.Count-1)
                    {
                        i = 0;
                        k++;
                    }


                }
                //number[k, i] = Convert.ToDouble(temp);
            }
            //MessageBox();
            //double[,] lines = File.ReadAllLines("1.txt", Encoding.Default); // задание переменной Lines, считывание всех строк из текстового документа

            /*dataGridView1.Rows.Clear(); // очищение*/ 
            for (int i = 0; i < dataGridView1.Columns.Count-1; i++)
                for (int k = 0; k < dataGridView1.Columns.Count-1; k++)

                {
                    dataGridView1.Rows.Add();
                    // dataGridView1.Rows[i].Cells[0].Value = lines[i];
                    dataGridView1.Rows[i].Cells[k + 1].Value = number[k, i].ToString();
                    //dataGridView1.Rows[k].Cells[i + 1].Value = number[i, k].ToString();
                    //  dataGridView1.Rows[k].Cells[i + 1].Value = lines[i, k].ToString();
                    //  dataGridView1.Rows[i].Cells[k + 1].Value = lines[k, i].ToString();
                }

            /* foreach (var line in File.ReadLines("Res_Matr.txt"))
             {
                 var array = line.Split();
                 for (int i = 0; i < "Res_Matr.txt"; i++)

                     for (int k = 0; k < "Res_Matr.txt"; k++)
                     {
                         dataGridView1.Rows[k].Cells[i + 1].Value = "Res_Matr.txt"[i, k].ToString();
                         dataGridView1.Rows[i].Cells[k + 1].Value = "Res_Matr.txt"[k, i].ToString();
                     } 
                 dataGridView1.Rows.Add(array);

             } */

        }

        private void button4_Click(object sender, EventArgs e)
        {       
                // Припуск задаем
                double[,] pripusk; //тип массива[запятая обозначает строку и столбец], имя массива;
                pripusk = new double[dataGridView3.Columns.Count - 1, dataGridView3.Columns.Count - 1]; // инициализируем массив           

                for (int i = 0; i < dataGridView3.Columns.Count - 1; i++)

                {
                    for (int j = 0; j < dataGridView3.Columns.Count - 1; j++)
                    {
                        pripusk[i, j] = Convert.ToDouble(dataGridView3[i + 1, j].Value);
                    }
                }
            

                // Допуск
                double[,] dopusk; //тип массива[запятая обозначает строку и столбец], имя массива;
                dopusk = new double[dataGridView2.Columns.Count - 1, dataGridView2.Columns.Count - 1]; // инициализируем массив           

                for (int i = 0; i < dataGridView2.Columns.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count - 1; j++)
                    {
                        dopusk[i, j] = Convert.ToDouble(dataGridView2[i + 1, j].Value);
                    }
                }

                //выполнить расчет              
                bool flag = true;
                do
                {
                    flag = false;
                    for (int i = 0; i < dopusk.GetLength(0); i++)
                    {
                        for (int j = 0; j < dopusk.GetLength(1); j++)
                        {
                            if (dopusk[j, i] != 0)
                            {

                                for (int k = i + 1; k < dopusk.GetLength(0); k++)
                                {
                                    if (dopusk[j, k] != 0)
                                    {
                                        if ((dopusk[j, i] + dopusk[j, k]) < dopusk[i, k] || dopusk[i, k] == 0)
                                        {
                                            dopusk[i, k] = dopusk[j, i] + dopusk[j, k];
                                            dopusk[k, i] = dopusk[i, k];
                                            flag = true;
                                        }
                                    }
                                }

                            }
                        }

                    }
                } while (flag == true);

                for (int i = 0; i < dopusk.GetLength(0); i++)

                    for (int k = 0; k < dopusk.GetLength(1); k++)
                    {
                        dataGridView2.Rows[k].Cells[i + 1].Value = dopusk[i, k].ToString();
                        dataGridView2.Rows[i].Cells[k + 1].Value = dopusk[k, i].ToString();
                    }          

            double [,] razmer; //тип массива[запятая обозначает строку и столбец], имя массива;
            razmer = new double[dataGridView1.Columns.Count-1, dataGridView1.Columns.Count-1]; // инициализируем массив           

            for (int i = 0; i < dataGridView1.Columns.Count-1; i++)

            {
                for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                {
                    razmer[i, j] = Convert.ToDouble(dataGridView1[i+1, j].Value);                
                }
            }
            // Средний припуск
            double[,] avpripusk; //тип массива[запятая обозначает строку и столбец], имя массива;
            avpripusk = new double[dataGridView4.Columns.Count - 1, dataGridView4.Columns.Count - 1]; // инициализируем массив           

            for (int i = 0; i < dataGridView4.Columns.Count - 1; i++)

            {
                for (int j = 0; j < dataGridView4.Columns.Count - 1; j++)
                {
                    avpripusk[i, j] = Convert.ToDouble(dataGridView4[i + 1, j].Value);
                }
            }
            for (int i = 0; i < avpripusk.GetLength(0); i++)
            {
                for (int j = 0; j < avpripusk.GetLength(1); j++)
                {
                    if (avpripusk[i, j] != 0)
                    {

                        //Берем данные из второй матрицы
                        razmer[i, j] = (avpripusk[i, j]) + (dopusk[i, j] / 2);
                        razmer[j, i] = -1 * razmer[i, j];

                    }
                }

            }
            //выполнить расчет            
            for (int i = 0; i < razmer.GetLength(0); i++)
            {
                for (int j = 0; j < razmer.GetLength(1); j++)
                {
                    if (razmer[i, j] != 0)
                    {
                        
                        for (int k = j+1; k<razmer.GetLength(0);k++)
                        {
                            if (razmer[i,k] != 0 && razmer[k,j] == 0)
                            {
                                //Берем данные из третьей матрицы
                                int stepen = 0;
                                double x = dopusk[k,j]; // напрмер x=0,01
                                while (Math.Truncate(x) == 0) // проверяет, что целая часть равна нулю. 
                                {
                                    stepen++; // увеличиваем степень, считает количество знаков после нуля
                                    x = x * 10;                                 
                                }                              
                                
                                razmer[k, j] = (razmer[i, j]) - (razmer[i, k]);
                                if ((razmer[k,j]*(Math.Pow(10, stepen))) % 1 != 0)
                                {
                                    razmer[k, j] = (razmer[i, j] + (pripusk[i, j] / Math.Pow(10, stepen))) - (razmer[i, k] + (pripusk[i, k] / Math.Pow(10, stepen)));                                
                                    razmer[k, j] = Math.Round(razmer[k, j], stepen);
                                    
                                }

                                razmer[j, k] = -1 * razmer[k, j];

                            }
                        }

                    }
                }
                
            }
            
            for (int i = 0; i < razmer.GetLength(0); i++)                
                    for (int k = 0; k < razmer.GetLength(1); k++)
                    {
                        dataGridView1.Rows[k].Cells[i + 1].Value = razmer[i, k].ToString();
                        dataGridView1.Rows[i].Cells[k + 1].Value = razmer[k, i].ToString();
                    }
                    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив

            // 1. Открыть файл для записи
            fw = new FileStream("Res_Matr2.txt", FileMode.Create);

            // 2. Запись матрицы результата в файл
            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = dataGridView2.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);

            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int j = 0; j < dataGridView2.Columns.Count - 1; j++)
            {
                // формируем строку msg из элементов матрицы
                for (int i = 1; i < dataGridView2.Columns.Count; i++)
                    msg = msg + dataGridView2[i, j].Value + "  ";
                msg = msg + "\r\n"; // добавить перевод строки
            }

            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // 4. запись строк матрицы в файл
            StreamWriter sw = File.CreateText("2.txt");
            sw.WriteLine(msg);
            sw.Close();
            fw.Write(msgByte, 0, msgByte.Length);

            // 5. Закрыть файл
            if (fw != null) fw.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //dataGridView1.ColumnCount = 1; // число столбцов
            string textFromFile;
            using (FileStream fstream = File.OpenRead("3.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
            }
            double[,] number = new double[10, 10]; // задаем двойной массив, границы массива
            {
                int i = 0;
                int k = 0;
                string temp = "";
                foreach (char sym in textFromFile)
                {
                    if (sym != 32)
                    {
                        temp = temp + sym;
                    }
                    else if (temp != "")
                    {
                        number[k, i] = Convert.ToDouble(temp);
                        i++;
                        temp = "";
                    }
                    if (i == dataGridView3.Columns.Count - 1)
                    {
                        i = 0;
                        k++;
                    }


                }
                //number[k, i] = Convert.ToDouble(temp);
            }
            for (int i = 0; i < dataGridView3.Columns.Count - 1; i++)
                for (int k = 0; k < dataGridView3.Columns.Count - 1; k++)

                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[k + 1].Value = number[k, i].ToString();
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив

            // 1. Открыть файл для записи
            fw = new FileStream("Res_Matr.txt", FileMode.Create);

            // 2. Запись матрицы результата в файл
            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = dataGridView1.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);

            // 2.2. Теперь записать саму матрицу
            msg = "";
            for (int j = 0; j < dataGridView1.Columns.Count-1; j++)
            {
                // формируем строку msg из элементов матрицы
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                    msg = msg + dataGridView1[i,j].Value + "  ";
                msg = msg + "\r\n"; // добавить перевод строки
            }

            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // 4. запись строк матрицы в файл
            StreamWriter sw = File.CreateText("1.txt");
            sw.WriteLine(msg);
            sw.Close();
            fw.Write(msgByte, 0, msgByte.Length);

            // 5. Закрыть файл
            if (fw != null) fw.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(textBox2.Text);
            int k = n;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            for (int i = 0; i <= k; i++)
            {
                dataGridView3.Columns.Add(i.ToString(), i.ToString());

            }

            for (int i = 1; i <= n; i++)
            {

                dataGridView3.Rows.Add(i.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dataGridView1.ColumnCount = 1; // число столбцов
            string textFromFile;
            using (FileStream fstream = File.OpenRead("2.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
            }
            double[,] number = new double[10, 10]; // задаем двойной массив, границы массива
            {
                int i = 0;
                int k = 0;
                string temp = "";
                foreach (char sym in textFromFile)               
                {
                    if (sym != 32)
                    {
                        temp = temp + sym;                    
                    }
                    else if (temp != "")
                    {
                        number[k, i] = Convert.ToDouble(temp);
                        i++;
                        temp = "";
                    }
                    if (i == dataGridView2.Columns.Count - 1)
                    {
                        i = 0;
                        k++;
                    }


                }
                //number[k, i] = Convert.ToDouble(temp);
            }                      
            for (int i = 0; i < dataGridView2.Columns.Count - 1; i++)
                for (int k = 0; k < dataGridView2.Columns.Count - 1; k++)

                {
                    dataGridView2.Rows.Add();                
                    dataGridView2.Rows[i].Cells[k + 1].Value = number[k, i].ToString();                  
                }          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(textBox4.Text);
            int k = n;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            for (int i = 0; i <= k; i++)
            {
                dataGridView4.Columns.Add(i.ToString(), i.ToString());

            }

            for (int i = 1; i <= n; i++)
            {

                dataGridView4.Rows.Add(i.ToString());
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //dataGridView1.ColumnCount = 1; // число столбцов
            string textFromFile;
            using (FileStream fstream = File.OpenRead("4.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
            }
            double[,] number = new double[10, 10]; // задаем двойной массив, границы массива
            {
                int i = 0;
                int k = 0;
                string temp = "";
                foreach (char sym in textFromFile)
                {
                    if (sym != 32)
                    {
                        temp = temp + sym;
                    }
                    else if (temp != "")
                    {
                        number[k, i] = Convert.ToDouble(temp);
                        i++;
                        temp = "";
                    }
                    if (i == dataGridView4.Columns.Count - 1)
                    {
                        i = 0;
                        k++;
                    }


                }
                //number[k, i] = Convert.ToDouble(temp);
            }
            for (int i = 0; i < dataGridView4.Columns.Count - 1; i++)
                for (int k = 0; k < dataGridView4.Columns.Count - 1; k++)

                {
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells[k + 1].Value = number[k, i].ToString();
                }
        }
    }
}
