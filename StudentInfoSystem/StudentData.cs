using System.Collections.Generic;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private static List<Student> _testStudents;

        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return _testStudents;
            }
            set { }
        }

        private static void ResetTestStudentData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>
                {
                    new Student("asd", "asd", "ads", "asd", "asd","asd", "122", 12, 12, 12,Status.Certified),
                    new Student("asdf", "asdf", "adsf", "asdf", "asdf","asdf", "1234567891", 13, 13, 13,Status.Other),
                    new Student("asad", "aasd", "adsa", "asda", "asda","fadsd", "1034567890",123, 122, 12, Status.Interrupted)
                };

            }
        }
    }
}