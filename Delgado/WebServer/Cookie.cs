using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.WebServer
{
    /// <summary>
    /// A cookie
    /// </summary>
    public class Cookie
    {
        public string Name;
        private string _value = "";
        /// <summary>
        /// The value of the cookie
        /// </summary>
        public string Value { get=>_value;set {
                OnSet?.Invoke(value);
                _value = value;
            } 
        }
        /// <summary>
        /// Is executed after a cookie is modified
        /// </summary>
        /// <remarks>
        /// This should only be set by CookieDictionary
        /// </remarks>
        internal Action<string> OnSet;
    }
}
