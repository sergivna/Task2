using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class EventAdd : EventArgs
    {
        public string Info { get; set; }

        public EventAdd(string info)
        {
            Info = info;
        }
    }
}
