using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Core
{
    public sealed class SearchType
    {
        private readonly int _searchTypeValue;
        private readonly string _searchTypeName;
        private readonly string _searchTypeDisplayName;
        public SearchType(int searchType, string searchTypeName, string searchTypeDisplayName)
        {
            if (searchTypeName == null)
            {
                throw new ArgumentNullException("searchTypeName");
            }
            if (searchTypeDisplayName == null)
            {
                throw new ArgumentNullException("searchTypeDisplayName");
            }
            this._searchTypeValue = searchType;
            this._searchTypeName = searchTypeName;
            this._searchTypeDisplayName = searchTypeDisplayName;
        }
        public SearchType(int searchType, string searchTypeName)
            : this(searchType, searchTypeName, searchTypeName)
        { }
        public int Value
        {
            get { return this._searchTypeValue; }
        }
        public string Name
        {
            get { return this._searchTypeName; }
        }
        public string DisplayName
        {
            get { return this._searchTypeDisplayName; }
        }
        public readonly static SearchType Non = new SearchType(int.MaxValue, "NONE", "不存在");
        public readonly static SearchType PatientInfoSearch = new SearchType(10, "PatientInfoSearch", "病人信息查询");
        public readonly static SearchType ClinicSearchType = new SearchType(100, "ClinicSearchType", "门诊查询");
        public readonly static SearchType HospitalSearchType = new SearchType(100000, "HospitalSearchType", "住院查询");
        public readonly static SearchType HospitalPatientInfoSearch = new SearchType(101000, "HospitalPatientInfoSearch", "住院病人信息查询");
        public readonly static SearchType All = new SearchType(int.MinValue, "ALL", "所有查询");

    }
}
