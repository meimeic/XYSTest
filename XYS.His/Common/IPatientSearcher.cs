using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core.His;
using XYS.His.Model;
using XYS.Core;
namespace XYS.His.Common
{
    public enum PatientInfoQueryType
    {
        PID=1,CID,BaseInfo,Name
    }
    public delegate void PatientInfoQueryHandler(object sender,PatientInfoQueryEventArgs e);
    public class PatientInfoQueryEventArgs:EventArgs
    {

    }
    public interface IPatientSearcher : ISearch
    {
        List<PersonModel> getPatientInfo(SearchArgument argument);
        bool isLocalPatient(string pid);
        event PatientInfoQueryHandler PatientInfoQueryEvent;
    }
}
