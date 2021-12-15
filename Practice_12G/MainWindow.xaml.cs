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
using System.Windows.Threading;

namespace Practice_12G
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            Data.Text = now.ToString("D");

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Дроздов Г. ИСП-34", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GetKilobytes_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(bytes.Text))
            {
                MessageBox.Show("Введите кол-во килобайт!");
            }
            else
            {
                Kilobytes.Text = (int.Parse(bytes.Text) / 1024).ToString();
                bytes.Focus();
            }
        }

        private void GetAreaPerimeter_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(x1.Text) || String.IsNullOrEmpty(x2.Text) || String.IsNullOrEmpty(y1.Text) || String.IsNullOrEmpty(y2.Text))
            {
                MessageBox.Show("Введите координаты!");
            }
            else
            {
                area.Text = Math.Abs((int.Parse(x2.Text) - int.Parse(x1.Text)) * (int.Parse(y2.Text) - int.Parse(y1.Text))).ToString();
                perimeter.Text = Math.Abs((int.Parse(x2.Text) - int.Parse(x1.Text) +
                    (int.Parse(y2.Text) - int.Parse(y1.Text))) * 2).ToString();
                x1.Focus();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            x1.Clear();
            x2.Clear();
            y1.Clear();
            y2.Clear();
            area.Clear();
            perimeter.Clear();
        }

        private void valueTextChange_TextChanged(object sender, TextChangedEventArgs e)
        {
            area.Clear();
            perimeter.Clear();
            Kilobytes.Clear();
        }
    }
}
