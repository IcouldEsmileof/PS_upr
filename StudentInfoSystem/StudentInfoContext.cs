using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }


        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            return countStudents == 0 ? true : false;
        }

        public void CopyTestStudent()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }

        private static List<Student> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }
    }
}