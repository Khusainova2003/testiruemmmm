using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;


namespace _3_Zadanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void indexA_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
       
        }
        private void indexB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }
        private void indexB_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void indexA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == true)
            {
                string filename = openDialog.FileName;
                massiv.Text = File.ReadAllText(filename);
            }
            if (massiv.Text.Any(c => char.IsLetter(c)))
            {
                MessageBox.Show("В файле имеются буквы");
                massiv.Clear();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (massiv.Text == "")
            {
                MessageBox.Show("Файл не может быть сохранен!");
            }
           else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filename = saveFileDialog.FileName;
                    File.WriteAllText(filename, massiv.Text);
                    MessageBox.Show("Файл сохранен!");
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            indexA.Text = Regex.Replace(indexA.Text, @"\s{2,}", "");
            indexB.Text = Regex.Replace(indexB.Text, @"\s{2,}", "");
            massiv.Text = Regex.Replace(massiv.Text, @"\s{2,}", "");
            if (indexA.Text == "" || indexB.Text == "" || massiv.Text == "")
            {
                MessageBox.Show("Введите все данные!");
            }
            else
            {
                if (Convert.ToInt32(indexA.Text) > Convert.ToInt32(indexB.Text))
                {
                    MessageBox.Show("Индекс A не может быть больше индекса B");
                    indexA.Text = "";
                    indexB.Text = "";
                }
                else
                {
                    if (Convert.ToInt32(indexA.Text) == Convert.ToInt32(indexB.Text))
                    {
                        MessageBox.Show("Индексы не могут быть равны!");
                        indexA.Text = "";
                        indexB.Text = "";
                    }
                    else
                    {
                        int[] mas = massiv.Text.Split(' ').Select(int.Parse).ToArray();
                        int max1 = mas[0];
                        if (Convert.ToInt32(indexA.Text) > mas.Length || Convert.ToInt32(indexB.Text) > mas.Length)
                        {
                            MessageBox.Show("Индексы не могут быть больше размера массива!");
                            indexA.Text = "";
                            indexB.Text = "";
                        }
                        else
                        {
                            for (int i = Convert.ToInt32(indexA.Text); i < Convert.ToInt32(indexB.Text); i++)
                            {
                                if (mas[i] > max1)
                                {
                                    max1 = mas[i];
                                }
                            }
                            result.Text = Convert.ToString(max1);
                        }
                    }
                }
            }
        }
    }
}
