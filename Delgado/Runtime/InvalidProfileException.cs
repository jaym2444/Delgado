using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Runtime
{
    public class InvalidProfileException : Exception
    {
        public InvalidProfileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
