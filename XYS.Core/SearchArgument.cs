using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Core
{
    public  class SearchArgument
    {
        private string _pid;
        public string PID
        {
            get { return this._pid; }
            set { this._pid = value; }
        }
    }
}
