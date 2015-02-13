using System;
using System.Collections.Generic;
using XYS;
using XYS.DAL;
using XYS.Model;
namespace XYS.DAL.MedicalRecord
{
    public class PatMasterIndex:IRecord
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public List<IResultModel> Search(SearchArgument argument)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(T t)
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T t)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T t)
        {
            throw new NotImplementedException();
        }
    }
}
