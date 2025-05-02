using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN_CONTROL_EXCEPTIONS.EXCEPTION_RESPONSE
{
    internal class CustomOwnerException : Exception
    {
        public CustomOwnerException( string Message ) : base(Message){ }   
    }
}
