using System;
using System.Collections.Generic;
using System.Linq;


namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                _testUsers.Add(new User());
                _testUsers[0].FakNum = "123";
                _testUsers[0].Password = "admin007";
                _testUsers[0].Username = "admin007";
                _testUsers[0].Role = (int) UserRole.Admin;
                _testUsers[0].Created = DateTime.Now;
                _testUsers[0].ActiveTo = DateTime.MaxValue;
                _testUsers.Add(new User());
                _testUsers[1].FakNum = "122";
                _testUsers[1].Password = "student1";
                _testUsers[1].Username = "student1";
                _testUsers[1].Role = (int) UserRole.Student;
                _testUsers[1].Created = DateTime.Now;
                _testUsers[1].ActiveTo = DateTime.MaxValue;
                _testUsers.Add(new User());
                _testUsers[2].FakNum = "121";
                _testUsers[2].Password = "student2";
                _testUsers[2].Username = "student2";
                _testUsers[2].Role = (int) UserRole.Student;
                _testUsers[2].Created = DateTime.Now;
                _testUsers[2].ActiveTo = DateTime.MaxValue;
            }
        }

        public static User IsUserPassCorrect(string username, string pass)
        {
            UserContext context = new UserContext();
            if (context.TestStudentsIfEmpty())
            {
                context.CopyTestStudent();
            }
            foreach (User u in context.Users)
            {
                if (u.Username == username && u.Password == pass)
                {
                    return u;
                }
            }

            return null;
        }

        public static void SetUserActiveTo(string uname, DateTime activeTo)
        {
            UserContext context =
                new UserContext();
            if (context.TestStudentsIfEmpty())
            {
                context.CopyTestStudent();
            }
            User usr =
                (from u in UserData.TestUsers
                    where u.Username == uname
                    select u).First();
            usr.ActiveTo = activeTo;
            context.SaveChanges();
        }

        public static void AssignUserRole(string uname, UserRole role)
        {
            UserContext context =
                new UserContext();
            if (context.TestStudentsIfEmpty())
            {
                context.CopyTestStudent();
            }
            User usr =
                (from u in UserData.TestUsers
                    where u.Username == uname
                    select u).First();
            usr.Role = (int) role;
            context.SaveChanges();
        }
    }
}