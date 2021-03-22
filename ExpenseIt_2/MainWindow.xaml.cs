using System.Windows;

namespace ExpenseIt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExpenseItHome homeWindow = new ExpenseItHome {Height = this.Height, Width = this.Width};
            homeWindow.Show();
            this.Close();
        }
    }
}