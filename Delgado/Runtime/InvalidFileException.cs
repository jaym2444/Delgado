using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Runtime
{
    /// <summary>
    /// An exception to be thrown if a given file is invalid
    /// </summary>
    public class InvalidFileException : Exception
    {
        /// <summary>
        /// When a file loaded is not the file expected
        /// </summary>
        /// <param name="message">The message</param>
        public InvalidFileException(string message) : base(message)
        {
        }
    }
}
