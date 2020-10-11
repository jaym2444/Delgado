using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.WebServer
{
    /// <summary>
    /// A webserver that handles requests and actions for everything
    /// </summary>
    public class SingletonWebserver : WebServer
    {
        /// <summary>
        /// There is a new incoming request
        /// </summary>
        public event Action<HttpRequest> OnRequest; 
        public SingletonWebserver(string host, int port) : base(host, port)
        {
        }

        protected override void ProcessRequest(HttpRequest request)
        {
            OnRequest?.Invoke(request);
            if (OnRequest.GetInvocationList().Length == 0)
                request.Respond("This request is not handled.", System.Net.HttpStatusCode.BadRequest);
        }
    }
}
