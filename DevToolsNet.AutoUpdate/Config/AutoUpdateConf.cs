using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.AutoUpdate.Config
{
    public class AutoUpdateConf
    {
        public const string dmFull = "full";
        public const string dmDiff = "diff";
        public const string dmNew = "new";
        
        public const string stGit = "git";
        public const string stFTP = "ftp";
        public const string stFolder = "folder";
        public const string stAPI = "api";
        public const string stDLL = "dll";

        public string AppRun { get; set; } // path to application
        public string AppName { get; set; }
        public string Version { get; set; }
        public string DownloadMode { get; set; } // Full, Diff, New
        public string SourceType { get; set; } // GIT, FTP, Folder, API, Dll
        public string Source { get; set; }
        public string ExtraInfo { get; set; }
    }
}