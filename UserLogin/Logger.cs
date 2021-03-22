using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static string FileName
        {
            get { return "D:\\Icould\\C#\\PS_project\\PS_project\\UserLogin\\log.txt"; }
            private set { }
        }

        public static void LogActivity(string activity)
        {
            string str = DateTime.Now + ";" +
                         LoginValidation.CurrentUserUsername + ";" +
                         LoginValidation.CurrentRole + ";" +
                         activity;
            currentSessionActivities.Add(str);
            //Console.WriteLine(FileName);
            File.AppendAllLines(FileName, new[] {str});

            LogContext context = new LogContext();
            context.Logs.Add(new Log(str));
            context.SaveChanges();
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder s = new StringBuilder();
            currentSessionActivities.ForEach(i => s.Append(i + "\n"));
            return s.ToString();
        }
    }
}