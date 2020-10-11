using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Delgado.WebServer
{
    /// <summary>
    /// A web server that handles its requests through routes
    /// </summary>
    public class RoutedWebServer : WebServer
    {
        /// <summary>
        /// Holds all of the routes to be used by the webserver
        /// </summary>
        public readonly Dictionary<string, Action<HttpRequest>> Routes = new Dictionary<string, Action<HttpRequest>>();
        public RoutedWebServer(string host, int port) : base(host, port)
        {
        }

        protected override void ProcessRequest(HttpRequest request)
        {
            var path = request.InnerContext.Request.Url.AbsolutePath;
            if (Routes.ContainsKey(path))
            {
                Routes[path](request); return;
            }
            if (Routes.ContainsKey(path.TrimStart('/')))
            {
                Routes[path.TrimStart('/')](request); return;
            }
            if (Routes.ContainsKey(path.TrimEnd('/')))
            {
                Routes[path.TrimEnd('/')](request); return;
            }
            if (Routes.ContainsKey(path.TrimStart('/').TrimEnd('/')))
            {
                Routes[path.TrimStart('/').TrimEnd('/')](request); return;
            }
            request.Respond("This request is not handled.", System.Net.HttpStatusCode.BadRequest);
        }
    }
}
