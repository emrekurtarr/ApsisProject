using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Utilities.Result
{
    public class Result : IResult
    {
        public string Message { get; }

        public bool Success { get; }


        public Result(string message,bool success):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
    }
}
