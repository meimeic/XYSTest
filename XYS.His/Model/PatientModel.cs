using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Model;
namespace XYS.His.Model
{
    public class PatientModel:PersonModel
    {
        private string _patientID;
        private string _identify;
        private bool _medicalRecord;
        public PatientModel()
        { }
        public string PID
        {
            set { this._patientID = value; }
            get { return this._patientID; }
        }
        public string Identify
        {
            set { this._identify = value; }
            get { return this._identify; }
        }
        public bool MedicalRecord
        {
            set { this._medicalRecord = value; }
            get { return this._medicalRecord; }
        }
    }
}
