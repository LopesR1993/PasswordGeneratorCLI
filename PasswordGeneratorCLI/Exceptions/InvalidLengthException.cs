using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCLI.Exceptions
{
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException(string message) : base(message)
        {
            
        }
    }
}
