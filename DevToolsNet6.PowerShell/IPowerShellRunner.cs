namespace DevToolsNet.PowerShell
{
    public interface IPowerShellRunner
    {
        public delegate void MessageOutDelegate(IPowerShellRunner runner, string msg);

        string Key { get; set; }

        event MessageOutDelegate ErrorMessaje;
        event MessageOutDelegate InfoMessaje;
        event MessageOutDelegate TextMessaje;
        event MessageOutDelegate WarningMessaje;

        void Dispose();
        void RunCommand(string command);

    }
}