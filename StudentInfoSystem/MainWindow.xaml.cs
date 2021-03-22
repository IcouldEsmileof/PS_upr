using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
            //Status.Do_not_use.GetStatuses().ForEach(st => cbSt.Items.Add(new ComboBoxItem {Content = st}));
        }

        public void ResetAll()
        {
            ResetGrid(grPdata);
            ResetGrid(grSdata);
        }

        private void ResetGrid(Grid grid)
        {
            foreach (UIElement iChild in grid.Children)
            {
                if (iChild is TextBox i)
                {
                    i.Text = "";
                }
                else if (iChild is ComboBox j)
                {
                    j.SelectedItem = new ComboBoxItem();
                }
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Login l = new Login();
            l.Show();
            this.Close();
        }

        
    }
}