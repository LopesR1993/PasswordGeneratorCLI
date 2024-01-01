using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCLI.Exceptions
{
    public class InvalidPromptException : Exception
    {
        public InvalidPromptException(string message):base(message)
        {
            
        }
    }
}
