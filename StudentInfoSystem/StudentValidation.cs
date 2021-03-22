using System;
using System.Windows.Controls;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student getStudentDataByUser(User user)
        {
            if (user.FakNum.Length == 0 || user.Role != (int)UserRole.Student)
            {
                Console.WriteLine("No a student");
                return null;
            }
            Student s = null;
            if ((s=getStudentFromList(user.FakNum))==null)
            {
                Console.WriteLine("Not in student's list");
                return null;
            }
            return s;
        }
        private Student getStudentFromList(string facNo)
        {
            foreach(Student i in StudentData.TestStudents)
            {
                if (i.FacNo.Equals(facNo))
                {
                    return i;
                }
            }
            return null;
        }
    }
}