using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace Delgado.WebServer
{
    /// <summary>
    /// Handles all of the web components for the Delgado client
    /// </summary>
    public abstract class WebServer
    {
        private Thread _serverThread;
        private HttpListener _listener = new HttpListener();
        private int _port = 8001;
        private string _host = "127.0.0.1";
        /// <summary>
        /// The port of the server
        /// </summary>
        public int Port { get => _port; private set => _port = value; }
        /// <summary>
        /// The interface of the server
        /// </summary>
        public string Interface { get => _host; private set => _host = value; }

        /// <summary>
        /// Processes an incoming request by the client
        /// </summary>
        /// <param name="request"> the request</param>
        protected abstract void ProcessRequest(HttpRequest request);

        private void Listen()
        {
            _listener.Prefixes.Add($"http://{Interface}:{Port}/");
            while (true)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    ProcessRequest(new HttpRequest(context));
                }catch (Exception ex)
                {
                    throw new WebListenException("The listener failed to handle a request", ex);
                }
            }
        }

        private void Initialize()
        {
            _serverThread = new Thread(Listen);
            _serverThread.Start();
        }

        /// <summary>
        /// Creates a new webserver
        /// </summary>
        /// <param name="host">The host interface of the server</param>
        /// <param name="port">The port of the server</param>
        public WebServer(string host, int port)
        {
            (_host, _port) = (host, port);
            Initialize();
        }
    }
}
