using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base(Properties.Settings.Default.DbConnect)
        {
            
        }

        public bool TestStudentsIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryStudents = context.Users;
            int countStudents = queryStudents.Count();

            return countStudents == 0 ? true : false;
        }

        public void CopyTestStudent()
        {
            UserContext context = new UserContext();
            foreach (User st in UserData.TestUsers)
            {
                context.Users.Add(st);
            }

            context.SaveChanges();
        }

        private static List<User> GetRegions()
        {
            UserContext context = new UserContext();
            List<User> users = context.Users.ToList();
            return users;
        }
    }
}
