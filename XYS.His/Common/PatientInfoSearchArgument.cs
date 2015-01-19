using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core;
using XYS;
namespace XYS.His.Common
{
    public sealed class PatientInfoSearchArgument:SearchArgument
    {
        private string _cid;
        private string _name;
        private Sex _sex;
        private Age _age;
        public PatientInfoSearchArgument()
        {
            this._age = new Age();
        }
        public string CID
        {
            get { return this._cid; }
            set { this._cid = value; }
        }
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public Age Ager
        {
            get { return this._age; }
            set { this._age = value; }
        }
        public Sex Gender
        {
            get { return this._sex; }
            set { this._sex = value; }
        }
    }
}
