using System;
using System.Collections.Generic;
using XYS.Model;
using XYS;
namespace XYS.Core.Common
{
    public delegate void PatientInfoQueryHandler(object sender,PatientInfoQueryEventArgs e);
    public class PatientInfoQueryEventArgs:EventArgs
    {

    }
    public interface IPatientSearcher : ISearch
    {
        List<IResultModel> getPatientInfo(SearchArgument argument);
        bool isLocalPatient(string pid);
        event PatientInfoQueryHandler PatientInfoQueryEvent;
    }
}
