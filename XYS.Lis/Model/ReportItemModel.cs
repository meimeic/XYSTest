using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Lis.Model
{
    public class ReportItemModel
    {
        #region 私有字段

        private int _dispNo;
        private int _itemNo;
        private string _itemName;
        private string _itemResult;
        private string _resultStatus;
        private string _itemUnit;
        private string _refRange;

        #endregion

        #region 公共属性

        public int DispNo
        {
            get { return _dispNo; }
            set { _dispNo = value; }
        }

        public int ItemNo
        {
            get { return _itemNo; }
            set { _itemNo = value; }
        }

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public string ItemResult
        {
            get { return _itemResult; }
            set { _itemResult = value; }
        }
        
        public string ResultStatus
        {
            get { return _resultStatus; }
            set { _resultStatus = value; }
        }
       
        public string ItemUnit
        {
            get { return _itemUnit; }
            set { _itemUnit = value; }
        }

        public string RefRange
        {
            get { return _refRange; }
            set { _refRange = value; }
        }

        #endregion
    }
}
