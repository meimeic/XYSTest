using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core;
using XYS;
namespace XYS.His.Common
{
    public sealed class PIDSearchArgument:SearchArgument
    {
        private string _pid;
        public PIDSearchArgument()
            :base("病案号参数",100L)
        {
        }
        public PIDSearchArgument(string pid)
            : base("病案号参数", 100L)
        {
            this._pid = pid;
        }

        public string PID
        {
            get { return this._pid; }
            set { this._pid = value; }
        }
    }
}
