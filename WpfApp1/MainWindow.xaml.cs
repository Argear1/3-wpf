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

namespace WpfApp1
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

        private void Linear(object sender, RoutedEventArgs e)
        {
            TextBoxC.Visibility = Visibility.Hidden;
            TextBlockC.Visibility = Visibility.Hidden;
        }

        private void Quadratic(object sender, RoutedEventArgs e)
        {
            TextBoxC.Visibility = Visibility.Visible;
            TextBlockC.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a, b, c = 0;

            if (!double.TryParse(TextBoxA.Text, out a) || !double.TryParse(TextBoxB.Text, out b) || (LinearButton.IsChecked == false && !double.TryParse(TextBoxC.Text, out c)))
            {
                MessageBox.Show("Введите корректные коэффициенты");
                return;
            }

            if (LinearButton.IsChecked == true)
            {
                if (a == 0)
                {
                    MessageBox.Show("Линейное уравнение не имеет решений, так как a = 0");
                }
                else
                {
                    double x = -b / a;
                    Solve.Text = $"x = {x}";
                }
            }
            else if (QuadraticButton.IsChecked == true)
            {
                if (a == 0)
                {
                    MessageBox.Show("Для квадратного уравнения a не может быть равно 0");
                }
                else
                {
                    double discriminant = b * b - 4 * a * c;

                    if (discriminant > 0)
                    {
                        double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                        Solve.Text = $"x1 = {x1}, x2 = {x2}";
                    }
                    else if (discriminant == 0)
                    {
                        double x = -b / (2 * a);
                        Solve.Text = $"x = {x}";
                    }
                    else
                    {
                        MessageBox.Show("Нет решений");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите тип уравнения");
            }
        }
    }
}
