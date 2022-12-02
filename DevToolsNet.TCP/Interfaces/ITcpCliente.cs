namespace DevToolsNet.TCP.Interfaces
{
    public interface ITcpCliente
    {
        string Key { get; }

        void CloseClient();
        void Send(byte[] data);
        void Send(string message);
    }
}