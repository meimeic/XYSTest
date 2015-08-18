using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Model;

namespace XYS.Lis.Model
{
    public class ReportInfoModel : PatientModel
    {
        #region 私有字段

        private string _reportTitle;
        private string _serialNo;
        private string _sampleNo;
        private string _sampleTypeName;
        private string _billingDoctor;
        private string _clinicalDiagnosis;
        private string _explanation;
        private string _collectDate;
        private string _collectTime;
        private string _inceptDate;
        private string _inceptTime;
        private string _testDate;
        private string _reportDate;
        private string _reportTime;
        private string _parItemName;
        private string _remark;

        #endregion

        #region 公共属性

        public string ReportTitle
        {
            get { return this._reportTitle; }
            set { this._reportTitle = value; }
        }

        public string SerialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }

        public string SampleNo
        {
            get { return _sampleNo; }
            set { _sampleNo = value; }
        } 

        public string SampleTypeName
        {
            get { return _sampleTypeName; }
            set { _sampleTypeName = value; }
        }
      
        public string BillingDoctor
        {
            get { return _billingDoctor; }
            set { _billingDoctor = value; }
        }

        public string ClinicalDiagnosis
        {
            get { return _clinicalDiagnosis; }
            set { _clinicalDiagnosis = value; }
        }

        public string Explanation
        {
            get { return _explanation; }
            set { _explanation = value; }
        }

        public string CollectDate
        {
            get { return _collectDate; }
            set { _collectDate = value; }
        }

        public string CollectTime
        {
            get { return _collectTime; }
            set { _collectTime = value; }
        }

        public string InceptDate
        {
            get { return _inceptDate; }
            set { _inceptDate = value; }
        }

        public string InceptTime
        {
            get { return _inceptTime; }
            set { _inceptTime = value; }
        }

        public string TestDate
        {
            get { return this._testDate; }
            set { this._testDate = value; }
        }
        public string ReportDate
        {
            get { return _reportDate; }
            set { _reportDate = value; }
        }

        public string ReportTime
        {
            get { return _reportTime; }
            set { _reportTime = value; }
        }

        public string ParItemName
        {
            get { return this._parItemName; }
            set { this._parItemName = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion

    }
}
