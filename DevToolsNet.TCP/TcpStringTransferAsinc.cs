using System.Net.Sockets;
using System.Net;
using System.Text;
using DevToolsNet.Extensions;

namespace DevToolsNet.TCP
{
    public class TcpStringTransferAsinc : IDisposable
    {

        #region · Variables

        public enum TipoTrabajo { Client, Server }

        /// <summary> Tipo de funcionamiento del conector</summary>
        public TipoTrabajo tipo;


        /// <summary> Evento lanzado cuando se han recivido datos </summary>
        public event EventHandler DataReaded;
        public event EventHandler ClientChange;

        string uid;

        int listenerPort;
        IPAddress listenerAddress;
        TcpListener listener;

        int endPort;
        IPAddress endAddress;

        /// <summary> Últimos datos recividos </summary>
        public String RawRecivedData { get; set; }


        public int BufferSize { get; set; }

        string remoteEndPoint;


        public bool ResponseClient { get; set; }

        TcpClient client;
        byte[] bytesClient;

        public TcpClient LastServerClient;

        public List<TcpClient> Clientes { get; set; }

        #endregion


        #region · Constructores

        /// <summary>
        /// Conector TCP para el envío de datos, y recepción asincrona
        /// </summary>
        /// <param name="UId">Identificador único para la validación de la conexión</param>
        /// <param name="tipoTrabajo">IP destino</param>
        /// <param name="EndAddress">IP destino</param>
        /// <param name="EndPort">Puerto destino</param>
        public TcpStringTransferAsinc(string UId, TipoTrabajo tipoTrabajo, string address, int port)
        {
            Clientes = new List<TcpClient>();

            tipo = tipoTrabajo;

            ResponseClient = true;
            BufferSize = 8 * 1024;

            uid = UId;

            if (tipo == TipoTrabajo.Client)
            {
                endPort = port;
                endAddress = IPAddress.Parse(address);
            }
            else if (tipo == TipoTrabajo.Server)
            {
                listenerPort = port;
                listenerAddress = IPAddress.Parse(address);
            }
        }


        /// <summary>
        /// Conector TCP para el envío de datos, y recepción asincrona
        /// </summary>
        /// <param name="UId">Identificador único para la validación de la conexión</param>
        /// <param name="EndAddress">IP destino</param>
        /// <param name="EndPort">Puerto destino</param>
        /// <param name="ListenerAddress">IP de escucha</param>
        /// <param name="ListenerPort">Puerto de escucha</param>
        public TcpStringTransferAsinc(string UId, string EndAddress, int EndPort, string ListenerAddress, int ListenerPort)
        {
            Clientes = new List<TcpClient>();

            ResponseClient = false;
            BufferSize = 8 * 1024;

            uid = UId;
            if (!string.IsNullOrWhiteSpace(EndAddress) && EndPort > 0)
            {
                ResponseClient = true;
                endPort = EndPort;
                endAddress = IPAddress.Parse(EndAddress);
            }
            if (!string.IsNullOrWhiteSpace(ListenerAddress) && ListenerPort > 0)
            {
                listenerPort = ListenerPort;
                listenerAddress = IPAddress.Parse(ListenerAddress);
            }
        }

        #endregion


        #region · Funciones Server

        /// <summary> Inicia la escucha </summary>
        public void StartListening()
        {
            if (listener != null) { StopListening(); }

            listener = new TcpListener(listenerAddress, listenerPort);
            listener.Start();
            AcceptClient(listener);
        }


        /// <summary> Finaliza la escucha </summary>
        public void StopListening()
        {
            if (listener != null) { listener.Stop(); }
            listener = null;
            if (LastServerClient != null) { LastServerClient.Close(); }
            Clientes.ForEach(x => x.Close());
            Clientes.Clear();
        }


        public void SendDataToLastServerClient(string message)
        {
            if (LastServerClient != null)
            {
                if (LastServerClient.Connected)
                {
                    NetworkStream stream = LastServerClient.GetStream();

                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);

                }
                else
                {
                    LastServerClient = null;
                    if (ClientChange != null)
                    {
                        ClientChange(this, EventArgs.Empty);
                    }
                }
            }
        }


        /// <summary>
        /// aceptación del cliente
        /// </summary>
        /// <param name="tcpListener"></param>
        private void AcceptClient(TcpListener tcpListener)
        {
            try
            {

                Task<TcpClient> acceptTcpClientTask = Task.Factory.FromAsync<TcpClient>(tcpListener.BeginAcceptTcpClient, tcpListener.EndAcceptTcpClient, tcpListener);

                // This allows us to accept another connection without a loop.
                // Because we are within the ThreadPool, this does not cause a stack overflow.
                acceptTcpClientTask.ContinueWith(task =>
                {
                    OnAcceptConnection(task.Result);
                    AcceptClient(tcpListener);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch { }
        }


        /// <summary>
        /// Lectura del cliente
        /// </summary>
        /// <param name="tcpClient"></param>
        private void OnAcceptConnection(TcpClient tcpClient)
        {
            try
            {
                LastServerClient = tcpClient;
                if (!Clientes.Contains(tcpClient)) { Clientes.Add(tcpClient); }

                if (ClientChange != null)
                {
                    ClientChange(this, EventArgs.Empty);
                }

                StartReceive(tcpClient);

                if (DataReaded != null)
                {
                    DataReaded(this, EventArgs.Empty);
                }
            }
            catch { }
        }


        #endregion


        #region · Funciones Client

        /// <summary>
        /// Envia una cadena a la ruta configurada
        /// </summary>
        /// <param name="message">Mensaje a enviar</param>
        public void SendString(string message)
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            SendData(data);
        }


        /// <summary>
        /// Envia los bytes a la ruta configurada
        /// </summary>
        /// <param name="message">Mensaje a enviar</param>
        public void SendData(Byte[] data)
        {
            bool newClient = false;
            if (client == null)
            {
                client = new TcpClient();
                newClient = true;
            }

            try
            {
                if (!client.Connected)
                {
                    client.Connect(endAddress, endPort);
                }


                if (ResponseClient && newClient)
                {
                    StartReceive(client);
                }

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                //stream.EndWrite(
                if (!ResponseClient)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
            finally
            {
                if (!ResponseClient)
                {
                    client.Close();
                    client = null;
                }
            }
        }


        public void CloseClient()
        {
            var stream = client.GetStream();
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }
        }



        public void Dispose()
        {
            this.StopListening();
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }


        private void StartReceive(TcpClient tcpClient)
        {
            bytesClient = new byte[0];
            byte[] buffer = new byte[BufferSize];

            try
            {
                if (tcpClient != null)
                {
                    if (tcpClient.Connected)
                    {
                        tcpClient.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceived, new KeyValuePair<TcpClient, byte[]>(tcpClient, buffer));
                    }
                    else
                    {
                        if (Clientes.Contains(tcpClient)) { Clientes.Remove(tcpClient); }
                    }
                }
            }
            catch { }
        }


        private void DataReceived(IAsyncResult ar)
        {
            int dataRead = 0;

            KeyValuePair<TcpClient, byte[]> dataAr = (KeyValuePair<TcpClient, byte[]>)ar.AsyncState;
            TcpClient tcpClient = dataAr.Key;

            try { dataRead = tcpClient.Client.EndReceive(ar); }
            catch
            {
                if (Clientes.Contains(tcpClient)) { Clientes.Remove(tcpClient); }
                return;
            }

            byte[] byteData = dataAr.Value; //ar.AsyncState as byte[];
            bytesClient = bytesClient.AppendArray(byteData.Take(dataRead).ToArray());

            if (ar.IsCompleted)
            {
                if (bytesClient.Length > 0)
                {
                    RawRecivedData = Encoding.ASCII.GetString(bytesClient).Trim('\0');

                    if (DataReaded != null)
                    {
                        DataReaded(this, EventArgs.Empty);
                    }

                    StartReceive(tcpClient);
                }
                else
                {
                    tcpClient.Close();
                }
            }
        }


        #endregion

    }

}