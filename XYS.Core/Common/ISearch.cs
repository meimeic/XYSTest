using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core;
namespace XYS.Core.Common
{
    public interface ISearch
    {
        string Name { get; }
        SearchType SearchCategory { get; }
    }
}
