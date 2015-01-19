using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core.His;
namespace XYS.His.Common
{
    public abstract class SuperPatient : IPatient
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }
        public void Query(ISearch search)
        {
            throw new NotImplementedException();
        }

        public ISearch Searcher
        {
            get { throw new NotImplementedException(); }
        }
    }
}
