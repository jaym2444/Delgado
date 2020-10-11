using Delgado.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Delgado.WebServer
{

    /// <summary>
    /// The request made by the client
    /// </summary>
    public class HttpRequest 
    {
        private bool _responded = false;
        private HttpListenerContext _context;
        
        /// <summary>
        /// The context of the request
        /// </summary>
        public HttpListenerContext InnerContext { get => _context; }
        /// <summary>
        /// If the request has been responded to
        /// </summary>
        public bool Responded { get => _responded; }
        /// <summary>
        /// The name of the machine making the requests
        /// </summary>
        /// <remarks>
        /// This only works on local networks and is completely meant only for use in the authorization process so the user knows where the request is originating from.
        /// </remarks>
        internal string MachineName { get
            {
                return Dns.GetHostEntry(_context.Request.RemoteEndPoint.Address.ToString()).HostName;
            } 
        }
        /// <summary>
        /// Creates a new HttpRequest object
        /// </summary>
        /// <param name="context">The context of the request</param>
        public HttpRequest(HttpListenerContext context)
        {
            (_context) = context;
        }

        /// <summary>
        /// Responds from a reply with the html
        /// </summary>
        /// <param name="html">The source to respond with</param>
        /// <param name="code">The response code</param>
        public void Respond(string html, HttpStatusCode code = HttpStatusCode.OK)
        {
            var input = html.ToStream();
            _context.Response.ContentType = "text/html";
            _context.Response.ContentLength64 = input.Length;
            _context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
            _context.Response.AddHeader("Last-Modified", System.IO.Directory.GetLastWriteTime(AppDomain.CurrentDomain.BaseDirectory).ToString("r"));
            byte[] buffer = new byte[1024 * 16];
            int nbytes;
            while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                _context.Response.OutputStream.Write(buffer, 0, nbytes);
            input.Close();
            _context.Response.StatusCode = (int)code;
            _context.Response.OutputStream.Flush();
            _context.Response.OutputStream.Close();

        }
    }
}
