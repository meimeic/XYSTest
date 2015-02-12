using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.His.Common;
using XYS.His.Model;
using XYS.Core;
using XYS.Core.His;
using XYS;
namespace XYS.His.Hospital
{
    public class HospitalPatientInfoSearch:IPatientSearcher
    {
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

        public event PatientInfoQueryHandler PatientInfoQueryEvent;

        public SearchType MyType
        {
            get { throw new NotImplementedException(); }
        }

        public List<XYS.Model.PersonModel> getPatientInfo(SearchArgument argument)
        {
            throw new NotImplementedException();
        }

        public bool isLocalPatient(string pid)
        {
            throw new NotImplementedException();
        }


        public SearchType SearchCategory
        {
            get { throw new NotImplementedException(); }
        }
    }
}
