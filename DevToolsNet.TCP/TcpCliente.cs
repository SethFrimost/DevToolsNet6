using DevToolsNet.Extensions;
using DevToolsNet.TCP.Configs;
using DevToolsNet.TCP.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.TCP
{
    public class TcpCliente : TcpBase, ITcpCliente, IDisposable
    {
        public string Key => config?.Key;

        TcpConfig config;
        TcpClient client;

        public TcpCliente(TcpConfig config)
        {
            this.config = config;
            this.BufferSize=config.BufferSize;

            client = new TcpClient(config.Address, config.Port);
            StartReceive(client);
        }

        /// <summary>
        /// Envia una cadena a la ruta configurada
        /// </summary>
        /// <param name="message">Mensaje a enviar</param>
        public void Send(string message)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            Send(data);
        }


        /// <summary>
        /// Envia los bytes a la ruta configurada
        /// </summary>
        /// <param name="message">Mensaje a enviar</param>
        public void Send(Byte[] data)
        {
            if (client == null)
            {
                client = new TcpClient(config.Address, config.Port);
                StartReceive(client);
            }

            if (!client.Connected)
            {
                client.Connect(config.Address, config.Port);
                StartReceive(client);
            }

            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
        }


        public void CloseClient()
        {
            var stream = client?.GetStream();
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }

            if (client != null)
            {
                client.Close();
                client.Dispose();
                client = null;
            }
        }

        public void Dispose()
        {
            if (client != null)
            {
                var stream = client.GetStream();
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
                client.Close();
                client.Dispose();
                client = null;
            }
        }

    }
}
