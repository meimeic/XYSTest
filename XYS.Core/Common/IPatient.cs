using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace XYS.Core.Common
{
    public interface IPatient
    {
        string Name { get; }
        void Query(ISearch search);
        ISearch Searcher { get; }
    }
}
