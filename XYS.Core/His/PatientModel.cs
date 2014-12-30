using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS;
namespace XYS.His
{
    public class PatientModel:PersonModel
    {
        private string _patientID;
        public PatientModel()
        { }
        public string PID
        {
            set { this._patientID = value; }
            get { return this._patientID; }
        }
    }
}
