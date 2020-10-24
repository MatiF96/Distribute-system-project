using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystem.Utils
{
    public class ErrorMessage
    {
        public string Message { get; set; }

        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
