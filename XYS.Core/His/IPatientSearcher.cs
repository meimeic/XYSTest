using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Model;
using XYS;
namespace XYS.Core.His
{
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
