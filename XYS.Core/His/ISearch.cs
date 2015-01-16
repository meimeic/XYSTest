using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Core;
namespace XYS.Core.His
{
    public interface ISearch
    {
        string Name { get; }
        SearchType MyType { get; }
    }
}
