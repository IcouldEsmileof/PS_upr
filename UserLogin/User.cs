using System;
using System.Data.Common;

namespace UserLogin
{
    public class User
    {
        public Int32 UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FakNum { get; set; }
        public Int32 Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveTo { get; set; }

        public override string ToString()
        {
            return Username + " " + Role + " " + ActiveTo;
        }
    }
}