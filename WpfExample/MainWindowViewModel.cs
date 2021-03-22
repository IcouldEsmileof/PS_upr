using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;
        private string text = "Здрасти!";

        public string HiButtonContent => "Click for time";


        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (PropertyChanged != null)
                {
                    //Tell WPF that this property changed
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        public bool CanExecute
        {
            get => this.canExecute;
            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get => toggleExecuteCommand;
            set => toggleExecuteCommand = value;
        }

        public ICommand HiButtonCommand
        {
            get => hiButtonCommand;
            set => hiButtonCommand = value;
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }

        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control

            Text = "Днес е " + DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString() + " часа";
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}