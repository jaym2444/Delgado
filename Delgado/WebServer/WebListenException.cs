using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.WebServer
{
    /// <summary>
    /// An exception for when there are issues with processing a web request
    /// </summary>
    public class WebListenException : Exception
    {
        /// <summary>
        /// Handles a web request issue
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public WebListenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
