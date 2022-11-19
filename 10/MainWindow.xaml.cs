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

namespace _10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> array;
        public MainWindow()
        {
            InitializeComponent();
            array = new List<int>();
        }
        private void AutoFill(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberBox.Text, out int number))
            {
                MessageBox.Show("Invalid number!");
                return;
            }
            array.Clear();
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                array.Add(rnd.Next(1, 100));
            }
            ArrayBox.Text = String.Join(" ", array);
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberBox.Text, out int number))
            {
                MessageBox.Show("Invalid number!");
                return;
            }
            array.Add(number);
            ArrayBox.Text = String.Join(" ", array);
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumberBox.Text, out int number))
            {
                MessageBox.Show("Invalid number!");
                return;
            }
            array.Remove(number);
            ArrayBox.Text = String.Join(" ", array);
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            array.Clear();
            ArrayBox.Clear();       
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(MinBox.Text, out int min) || !int.TryParse(MaxBox.Text, out int max) || min > max)
            {
                MessageBox.Show("Invalid interval!");
                return;
            }
            for(int i = min; i <= max; i++)
            {
                foreach(int j in array)
                {
                    if(j == i)
                    {
                        ResultBox.Text = "The array contains an element from the interval";
                        return;
                    }
                }
            }
            ResultBox.Text = "The array doesn't contain an element from the interval";
        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Проверить, имеется ли в одномерном массиве хотя бы один элемент, попадающий в интервал[а; b]");
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
