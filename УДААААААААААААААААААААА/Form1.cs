using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;


namespace УДААААААААААААААААААААА
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dat1();
            Read();
          
           
        }
        public void Read()
        {
            listBox1.Items.Clear();

            string FilePath = Environment.CurrentDirectory + @"\DZ_XMas.txt";//в кавычках писать имя файла с расширением.

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                { listBox1.Items.Add(line); }
            }


        }
        public void Dat1()
        {
            //Это база данных меню ресторана
        
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
            dataGridView1.Columns.Add("info", "выберите кухню ил ресторан");
            dataGridView1.Rows.Add("пожалуйста");


            dataGridView2.Hide();//русская кухня

            dataGridView2.Columns.Add("info", "еда по русски");
            dataGridView2.Rows.Add("Блины");
            dataGridView2.Rows.Add("Борщ");
            dataGridView2.Rows.Add("Пельмени");
            dataGridView2.Rows.Add("Квас");
            dataGridView2.Rows.Add("Кисель из смородины");

            dataGridView3.Hide();//турецкая кухня

            dataGridView3.Columns.Add("info", "еда по турецки");
            dataGridView3.Rows.Add("Лукум");
            dataGridView3.Rows.Add("Турецкий кофе");
            dataGridView3.Rows.Add("Похлава");

            dataGridView4.Hide();//Макдональс
            dataGridView4.Columns.Add("info", "еда из Макдональса");
            dataGridView4.Rows.Add("мороженное с карамелью");
            dataGridView4.Rows.Add("мороженное с клубникой");
            dataGridView4.Rows.Add("мороженное с шеколадом");
            dataGridView4.Rows.Add("чикенбургер");
            dataGridView4.Rows.Add("картошка фри");
            dataGridView4.Rows.Add("нагитсы");
            dataGridView4.Rows.Add("креветки");

            dataGridView5.Hide();//Столовка

            dataGridView5.Columns.Add("info", "еда Английская");
            dataGridView5.Rows.Add("чай");
            dataGridView5.Rows.Add("пельмени");
            dataGridView5.Rows.Add("макароны");
            dataGridView5.Rows.Add("кисель");

            dataGridView6.Hide();// Английская кухня

            dataGridView6.Columns.Add("info", "еда Английская");
            dataGridView6.Rows.Add("Английский чай");
            dataGridView6.Rows.Add("Шеколад");
            dataGridView6.Rows.Add("жаренная индейка");
            dataGridView6.Rows.Add("бургер");
            dataGridView6.Rows.Add("картошка фри");
            dataGridView6.Rows.Add("нагитсы");
            dataGridView6.Rows.Add("пиво");
        }     


        private void button1_Click(object sender, EventArgs e)
        {
            string filpath = @"DZ_XMas.txt";//в кавычках писать имя файла с расширением.

            string ry = "";

            string Sum;
            using (StreamReader write = new StreamReader(filpath))// читает файл 
            {
                Sum = write.ReadToEnd();
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(filpath))
                {
                    ry = textBox1.Text;
                   
                    sw.WriteLine(Sum + ry);
                    // Sum = Sum + ry;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
            }

            Read();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void кухняToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void русскаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  string filpath = @"Русская кухня.txt";//в кавычках писать имя файла с расширением.

            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(filpath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dataGridView1.DataSource = line;
                }
            } */
            dataGridView1.Hide();
            dataGridView2.Show();
            dataGridView3.Hide();
            dataGridView4.Hide();
            dataGridView5.Hide();
            dataGridView6.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void турецкаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();
            dataGridView4.Hide();
            dataGridView5.Hide();
            dataGridView6.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                try
                {
                    string sourceFilePath =  Environment.CurrentDirectory + @"\DZ_XMas.txt";

                    // Выбор папки пользователем
                    string destinationFolder;
                    using (var fbd = new FolderBrowserDialog())
                    {
                        fbd.Description = "Выберите папку для сохранения файла";
                        if (fbd.ShowDialog() != DialogResult.OK)
                        {
                            // Пользователь отменил
                            return;
                        }
                        destinationFolder = fbd.SelectedPath;
                    }

                    // Ввод имени файла
                    string customFileName = Interaction.InputBox("Введите имя файла (с расширением):", "Имя файла", "DZ_XMas.txt");
                    if (string.IsNullOrWhiteSpace(customFileName))
                    {
                        // Пользователь ничего не ввел
                        return;
                    }

                    // Полный путь к новому файлу
                    string destinationFilePath = Path.Combine(destinationFolder, customFileName);

                    // Копирование файла
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Fil = Environment.CurrentDirectory + @"\DZ_XMas.txt";
            File.WriteAllText(Fil, "Корзина Заказа:\n");
            Read();
        }

        private void макдональсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Show();
            dataGridView5.Hide();
            dataGridView6.Hide();
        }

        private void столоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
            dataGridView5.Show();
            dataGridView6.Hide();
        }

        private void англйскаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();
            dataGridView5.Hide();
            dataGridView6.Show();
        }
    }

    

}
