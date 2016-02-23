using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    class Logger
    {
        public void Log(string message)
        {
            LogPosts.Add(message); // Add the message to a private List<string> }  

        }
        public List<string> LogPosts { get; private set; }

        //Default constructor
        public Logger()
        {
            LogPosts = new List<string>();


        }

    }
}

