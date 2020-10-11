using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Runtime
{
    /// <summary>
    /// When a macro is invalid
    /// </summary>
    public class InvalidMacroException : Exception
    {
        public InvalidMacroException(string message) : base(message)
        {
        }

        public InvalidMacroException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
