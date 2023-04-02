using DevToolsNet.TCP.Configs;
using DevToolsNet.TCP.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using DevToolsNet.Extensions;

namespace DevToolsNet.TCP
{
    public  class TcpServer : TcpBase, ITcpServer, IDisposable
    {
        public string Key => config?.Key;

        TcpConfig config;
        TcpListener listener;


        public List<TcpClient> clients = new List<TcpClient>();
        public TcpClient LastServerClient;


        public event EventHandler ClientConected;
        public event EventHandler ClientDisconected;

        public TcpServer(TcpConfig config)
        {
            this.config = config;
            this.BufferSize=config.BufferSize;
        }

        public TcpServer(IOptions<TcpConfig> config) : this(config.Value) { }


        public void Start()
        {
            if (listener != null) { Stop(); }

            listener = new TcpListener(IPAddress.Parse(config.Address), config.Port);
            listener.Start();
            AcceptConection();
        }

        private async void AcceptConection()
        {
            while(listener!=null)
            {
                try
                {
                    var cli = await listener.AcceptTcpClientAsync();
                    LastServerClient = cli;
                    OnAcceptConnection(cli);
                    _ = CheckCloseConection(cli);
                }
                catch
                {

                }
            }
        }

        private Task CheckCloseConection(TcpClient cli)
        {
            return Task.Run(() =>
            {
                while (listener != null)
                {
                    if (cli != null && !cli.Connected)
                    {
                        clients.Remove(cli);
                        cli = null;
                        ClientDisconected?.Invoke(this, EventArgs.Empty);
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        public void Stop()
        {
            if (listener != null) { listener.Stop(); }
            listener = null;
            if (LastServerClient != null) { LastServerClient.Close(); }
            clients.ForEach(x => x.Close());
            clients.Clear();
        }


        /// <summary>
        /// Lectura del cliente
        /// </summary>
        /// <param name="tcpClient"></param>
        private void OnAcceptConnection(TcpClient tcpClient)
        {
            LastServerClient = tcpClient;
            if (!clients.Contains(tcpClient)) { clients.Add(tcpClient); }

            ClientConected?.Invoke(this, EventArgs.Empty);

            StartReceive(tcpClient);
        }

        public void SendToLastServerClient(string message)
        {
            Send(LastServerClient, message);
        }

        public void SendToClients(string message)
        {
            foreach(var cli in clients)
            {
                Send(cli,message);
            }
        }

        private void Send(TcpClient cli, string msg)
        {
            if(cli != null)
            {
                //if (!cli.Connected) cli.Connect();
                byte[] data = Encoding.ASCII.GetBytes(msg);
                cli.GetStream().Write(data, 0, data.Length);
            }
        }


        public void Dispose()
        {
            this.Stop();
            if (LastServerClient != null)
            {
                LastServerClient.Close();
                LastServerClient.Dispose();
                LastServerClient = null;
            }
            if (clients != null)
            {
                clients.ForEach(c =>
                {
                    c.Close();
                    c.Dispose();
                });
                clients.Clear();
            }
        }

    }
}
