using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Utilities.Result
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
