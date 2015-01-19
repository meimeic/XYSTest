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
    public interface IPatientInfoSearch : ISearch
    {
        List<PersonModel> PatientInfoSearch(PatientInfoQueryType queryType, SearchArgument argument); 
        event PatientInfoQueryHandler PatientInfoQueryEvent;
    }
}
