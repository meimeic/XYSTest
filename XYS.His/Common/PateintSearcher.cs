using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core.His;
using XYS.Model;
namespace XYS.His.Common
{
    public class PateintSearcher:IPatientSearcher
    {
        private string _name;
        private SearchType _category;
        public PateintSearcher()
        {
            this._name = "门诊病人查询器";
            this._category = SearchType.PatientSearch;
        }
        public string Name
        {
            get {return this._name; }
        }
        public SearchType SearchCategory
        {
            get { return this._category; }
        }
        public List<PersonModel> getPatientInfo(SearchArgument argument)
        {
            throw new NotImplementedException();
        }
        protected internal virtual List<PersonModel> getPatientInfoByPID(SearchArgument argument)
        {
            PIDSearchArgument PIDArgument = argument as PIDSearchArgument;
            if (PIDArgument != null)
            {

            }
            else
            {
                throw new ArgumentNullException("argument");
            }
        }
        public bool isLocalPatient(string pid)
        {
            throw new NotImplementedException();
        }
        public event PatientInfoQueryHandler PatientInfoQueryEvent;
    }
}
