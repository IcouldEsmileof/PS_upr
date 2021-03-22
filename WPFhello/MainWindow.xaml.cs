using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    delegate double act(double aa, double aaa);
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem j = new ListBoxItem(), d = new ListBoxItem();
            j.Content = "James";
            d.Content = "David";
            peopleListBox.Items.Add(j);
            peopleListBox.Items.Add(d);
            peopleListBox.SelectedItem = j;
        }

        private void BrnHello_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            foreach (var iChild in grid.Children)
            {
                if (iChild is TextBox i)
                {
                    if (i.Name.Contains("txtName"))
                    {
                        if (i.Text.Length >= 2)
                        {
                            text+="Здрасти " + i.Text + "!!!\n";
                        }
                        else
                        {
                            text+="Името на "+i.Name.Remove(0,7)+" трябва да е с дължина поне 2 символа.\n";
                        }
                    }
                }
            }

            MessageBox.Show(text);
        }

        

        private void BtnNY_Click(object sender, RoutedEventArgs e)
        {
            double a = 1;
            double n = double.Parse(n_text.Text);
            long y = long.Parse(y_text.Text);
            act ac = Mul;
            if (y < 0)
            {
                ac = Div;
                y *= -1;
            }
                for (long i = 0; i < y; i++)
            {
                a = ac(a,n);
            }
            MessageBox.Show(n + "^" + y + "=" + a);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите приложението?", "Затваряне на приложение",MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BtnNfac_Click(object sender, RoutedEventArgs e)
        {
            long a = 1;
            int k=int.Parse(factN_text.Text);
            for(int i = 1; i <= k; i++)
            {
                a *= i;
            }
            MessageBox.Show(k + "!=" + a);
        }
        private static double Mul(double a,double i)
        {
            return a * i;
        }
        private static double Div(double a, double i)
        {
            return a / i;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myMessage = new MyMessage();
            myMessage.Show();
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi " + (peopleListBox.SelectedItem as ListBoxItem).Content);
        }
    }
}
