using System;
using System.Collections.Generic;
using System.Text;
using WSCookie = System.Net.Cookie;
namespace Delgado.WebServer
{
    /// <summary>
    /// A dictionary the holds cookies for a request
    /// </summary>
    public class CookieDictionary : Dictionary<string, Cookie>
    {
        private HttpRequest _request;
        /// <summary>
        /// Creates a new cookie dictionary
        /// </summary>
        /// <param name="request">The request for the dictionary to be created from</param>
        public CookieDictionary(HttpRequest request)
        {
            _request = request;
            foreach (WSCookie cookie in request.InnerContext.Request.Cookies)
            {
                Add(new Cookie()
                {
                    Name = cookie.Name,
                    Value = cookie.Value
                });
            }
        }
        /// <summary>
        /// Adds a new cookie to the dictionary
        /// </summary>
        /// <param name="key">The name of the cookie</param>
        /// <param name="value">The value of the cookie</param>
        public new void Add(string key, Cookie value)
        {
            value.OnSet = (string val) =>
            {
                foreach (WSCookie cookie in _request.InnerContext.Response.Cookies)
                {
                    if (cookie.Name == value.Name)
                    {
                        cookie.Value = val;
                    }
                }
            };
            _request.InnerContext.Response.AppendCookie(new WSCookie(key, value.Value, "/"));
            base.Add(key, value);
            
        }
        /// <summary>
        /// Adds a new cookie to the dictionary
        /// </summary>
        /// <param name="value">The cookie</param>
        public void Add(Cookie value)
        {
            Add(value.Name, value);
        }
    }
}
