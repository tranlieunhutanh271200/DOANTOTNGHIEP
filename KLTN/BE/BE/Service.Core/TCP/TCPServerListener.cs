using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Service.Core.TCP
{
    public class TCPServerListener : IDisposable
    {
        private TcpListener _listener;
        private TcpClient _worker;
        public string Name { get; private set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public TCPServerListener(string name, int port)
        {
            Name = name;
            Port = port;
            new Thread(Listen).Start();
        }
        public void Listen()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            while (true)
            {

            }
        }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;
            _listener.Stop();
        }
    }
}
