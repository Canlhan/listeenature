using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult  // Sende hem IResulttakiler var hem de T Data var
    {
        T Data { get; }
    }
}
