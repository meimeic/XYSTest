using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.His.Common;
using XYS.His.Model;
namespace XYS.His.Hospital
{
    public class HospitalPatientInfoSearch:IPatientInfoSearch
    {
        private string _pid;
        private string _cid;

        public PatientModel GetPatientInfo()
        {
            return null;
        }
        public PatientModel GetPatientInfo(string CID)
        {
            throw new NotImplementedException();
        }
        public string Name
        {
            get { throw new NotImplementedException(); }
        }
        public string SearchType
        {
            get { throw new NotImplementedException(); }
        }
        private string GetPID(string CID)
        {
            return null;
        }
    }
}
