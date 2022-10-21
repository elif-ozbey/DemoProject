using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult //this demek kendisi demek
    {
        
        public Result(bool success, string message):this(success) // 2 parametreli bir konstraktirdan sonra bu classida calistir. This demek bu demek
        {
           Message = message;
          
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string? Message { get; }
    }
}
