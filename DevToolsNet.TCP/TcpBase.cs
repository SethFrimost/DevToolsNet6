using DevToolsNet.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.TCP
{
    public abstract class TcpBase
    {
        protected int BufferSize = 8 * 1024;
        protected byte[] bytesClient;
        public string RawRecivedData;
        
        public event EventHandler DataReaded;

        protected virtual void StartReceive(TcpClient tcpClient)
        {
            bytesClient = new byte[0];
            byte[] buffer = new byte[BufferSize];

            //try
            //{
            if (tcpClient != null && tcpClient.Connected)
            {
                tcpClient.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceived, new KeyValuePair<TcpClient, byte[]>(tcpClient, buffer));
            }
            else
            {

            }
            //}
            //catch { }
        }


        protected virtual void DataReceived(IAsyncResult ar)
        {
            int dataRead = 0;

            KeyValuePair<TcpClient, byte[]> dataAr = (KeyValuePair<TcpClient, byte[]>)ar.AsyncState;
            TcpClient tcpClient = dataAr.Key;

            try {
                if (tcpClient?.Client != null)
                {
                    dataRead = tcpClient.Client.EndReceive(ar);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                //if (clients.Contains(tcpClient)) { clients.Remove(tcpClient); }
                return;
            }

            byte[] byteData = dataAr.Value; //ar.AsyncState as byte[];
            bytesClient = bytesClient.AppendArray(byteData.Take(dataRead).ToArray());

            if (ar.IsCompleted)
            {
                if (bytesClient.Length > 0)
                {
                    RawRecivedData = Encoding.ASCII.GetString(bytesClient).Trim('\0');

                    DataReaded?.Invoke(this, EventArgs.Empty);
                    StartReceive(tcpClient);
                }
                else
                {
                    tcpClient.Close();
                }
                
            }
        }
    }
}
