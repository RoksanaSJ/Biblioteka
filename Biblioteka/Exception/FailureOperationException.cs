using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Exception
{
    public class FailureOperationException : System.Exception
    {
        
        public FailureOperationException(string message) : base(message)
        {

        }
    }
}
