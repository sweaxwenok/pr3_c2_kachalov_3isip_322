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

namespace pr3_c2_kachalov_3isip_322
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
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка на пустые поля ввода
                if (string.IsNullOrEmpty(InputDistance.Text) || string.IsNullOrEmpty(InputTime.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                // Проверка на корректность ввода (натуральные числа)
                if (!double.TryParse(InputDistance.Text, out double distance) || distance <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение расстояния (натуральное число).");
                    return;
                }

                if (!double.TryParse(InputTime.Text, out double time) || time <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение времени (натуральное число).");
                    return;
                }

                // Проверка выбора единиц измерения
                if (RadioMetersPerSecond.IsChecked == false && RadioKilometersPerHour.IsChecked == false)
                {
                    MessageBox.Show("Пожалуйста, выберите единицы измерения скорости.");
                    return;
                }

                double speed = distance / time;

                if (RadioKilometersPerHour.IsChecked == true)
                {
                    speed = speed * 3.6;
                }

                OutputResult.Text = speed.ToString("F2");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
