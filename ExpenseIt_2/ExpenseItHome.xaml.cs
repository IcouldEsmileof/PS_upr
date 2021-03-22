using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ExpenseIt_2
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;

        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
        }

        private void openReport(object sender, RoutedEventArgs e)
        {
            ExpenseItReport er = new ExpenseItReport(this.peopleListBox.SelectedItem);
            er.Height = this.Height;
            er.Width = this.Width;
            er.ShowDialog();
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add(peopleListBox.SelectedItem.ToString() + ":" + (peopleListBox.SelectedItem as
                System.Xml.XmlElement)?.Attributes["Name"].Value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
