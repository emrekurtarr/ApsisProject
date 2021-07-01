using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Utilities.Result
{
    public class ErrorResult : Result
    {
        
        public ErrorResult(string message):base(message,false)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
