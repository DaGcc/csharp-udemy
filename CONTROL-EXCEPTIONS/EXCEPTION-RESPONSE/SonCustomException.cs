
using OWN_CONTROL_EXCEPTIONS.EXCEPTION_RESPONSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROL_EXCEPTIONS.EXCEPTION_RESPONSE
{
    internal class SonCustomException : CustomOwnerException
    {
        public SonCustomException(string Message) : base(Message)
        {
        }
    }
}
