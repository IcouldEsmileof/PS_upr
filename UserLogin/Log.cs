using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Log
    {
        public Int32 LogId { get; set; }
        public string Activity { get; set; }

        public Log()
        {
        }

        public Log(string activity)
        {
            Activity = activity;
        }
    }
}