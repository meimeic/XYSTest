﻿namespace XYS.Model
{
    public class PatientModel:PersonModel
    {
        private string _patientID;
        private string _clinicType;
        private string _bedNo;
        private string _deptName;
        public PatientModel()
        { }
        public string PID
        {
            set { this._patientID = value; }
            get { return this._patientID; }
        }
        public string ClinicType
        {
            set { this._clinicType = value; }
            get { return this._clinicType; }
        }
        public string BedNo 
        {
            get { return this._bedNo; }
            set { this._bedNo = value; }
        }
        public string DeptName
        {
            get { return this._deptName; }
            set { this._deptName = value; }
        }
    }
}
