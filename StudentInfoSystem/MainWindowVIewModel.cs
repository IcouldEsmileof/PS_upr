using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Annotations;
using System.Data;
using System.Data.SqlClient;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualStudio.PlatformUI;
using UserLogin;

namespace StudentInfoSystem
{
    class MainWindowVIewModel : INotifyPropertyChanged
    {
        public static Student __s;
        private Student _student = new Student();


        public MainWindowVIewModel()
        {
            LoginCommand = new DelegateCommand(Login);
            TestClickCommand = new DelegateCommand(TestClick);
            

        }



        public Student Student
        {
            get => _student;
            set
            {
                if (value != null)
                {
                    _student.Name = value.Name;
                    _student.Surname = value.Surname;
                    _student.FamilyName = value.FamilyName;

                    _student.Fac = value.Fac;
                    _student.Spec = value.Spec;
                    _student.OKS = value.OKS;
                    _student.Status = value.Status;
                    _student.FacNo = value.FacNo;

                    _student.Kurs = value.Kurs;
                    _student.Potok = value.Potok;
                    _student.Group = value.Group;
                    ShowStudent();
                }
                else
                {
                    DeactivateAll();
                }
            }
        }

        private bool _isEnabled = false;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => _isEnabled = value;
        }

        public void ShowStudent()
        {
            //Tell WPF that this property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Student"));
        }

        public void DeactivateAll()
        {
            IsEnabled = false;
            //Tell WPF that this property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
        }

        public void ActivateAll()
        {
            IsEnabled = true;
            //Tell WPF that this property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
                SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                for (notEndOfResult = reader.Read(); notEndOfResult;)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private string _uname = "";
        private string _pass = "";

        public string Uname
        {
            get => _uname;
            set => _uname = value;
        }

        public string Pass
        {
            get => _pass;
            set => _pass = value;
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand TestClickCommand { get; private set; }

        public void Login(object o)
        {
            LoginValidation lv = new LoginValidation(Uname, Pass, x => MessageBox.Show(x));
            User u;
            if (lv.ValidateUserInput(out u))
            {
                StudentValidation sv = new StudentValidation();
                Student student = sv.getStudentDataByUser(u);
                if (student != null)
                {
                    _student = student;
                    MainWindow main = new MainWindow();
                    main.DataContext = this;
                    FillStudStatusChoices();
                    ShowStudent();
                    ActivateAll();
                    main.Show();
                    (o as Login)?.Close(); 
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        public void TestClick(object sender)
        {
            StudentInfoContext s = new StudentInfoContext();
            if (s.TestStudentsIfEmpty())
                s.CopyTestStudent();
        }
    }
}