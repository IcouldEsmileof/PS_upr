using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseIT
{
    /// <summary>
    /// Interaction logic for ExpenseltHome.xaml
    /// </summary>
    public partial class ExpenseHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;

        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public ExpenseHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
        }

        private void openReport(object sender, RoutedEventArgs e)
        {
            ExpenseReport er = new ExpenseReport(this.peopleListBox.SelectedItem);
            er.Height = this.Height;
            er.Width = this.Width;
            er.ShowDialog();
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add(peopleListBox.SelectedItem.ToString());
            PersonsChecked.Add((peopleListBox.SelectedItem as
                System.Xml.XmlElement)?.Attributes["Name"].Value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}