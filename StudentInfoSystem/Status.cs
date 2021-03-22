using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace StudentInfoSystem
{
    public enum Status
    {
        Do_not_use=-1,
        Certified=1,
        Interrupted=2,
        SemesterGraduated=3,
        Other=4
    }

    internal static class StatusMethods
    {
        public static List<String> GetStatuses(this Status s1)
        {
            return new List<String>{"",Status.Certified.ToString(), Status.Interrupted.ToString(), Status.SemesterGraduated.ToString(), Status.Other.ToString()};
        }
    }
}