using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Runtime
{
    /// <summary>
    /// When a plugin manifest is invalid
    /// </summary>
    public class InvalidPluginManifestException : Exception
    {
        public InvalidPluginManifestException(string message) : base(message)
        {
        }

        public InvalidPluginManifestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
