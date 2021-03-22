using System;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FamilyName { get; set; }

        public string Fac { get; set; }

        public string Spec { get; set; }

        public string OKS { get; set; }

        public string FacNo { get; set; }

        public int Kurs { get; set; }

        public int Potok { get; set; }

        public int Group { get; set; }

        public Status Status { get; set; }

        public byte[] Photo { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, string familyName, string fac, string spec, string oks, string facNo, int kurs, int potok, int group, Status status)
        {
            Name = name;
            Surname = surname;
            FamilyName = familyName;
            Fac = fac;
            Spec = spec;
            OKS = oks;
            FacNo = facNo;
            Kurs = kurs;
            Potok = potok;
            Group = group;
            Status = status;
        }
    }
}