using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.His.Common;
using XYS.His.Model;
using XYS.Core;
using XYS.Core.His;
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

        public List<PersonModel> PatientInfoSearch(PatientInfoQueryType queryType, Core.SearchArgument argument)
        {
            throw new NotImplementedException();
        }

        public event PatientInfoQueryHandler PatientInfoQueryEvent;


        public Core.SearchType MyType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
