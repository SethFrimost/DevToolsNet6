using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace Servicios
{
    public static class ImpersonationUtil
    {
        public static bool Impersonate(string usr, string psw, string dom)
        {
            string logon = usr; // ConfigurationManager.AppSettings["ImpersonationUserName"];
            string password = psw; // ConfigurationManager.AppSettings["ImpersonationPassword"];
            string domain = dom; // ConfigurationManager.AppSettings["ImpersonationDomain"];

            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            WindowsImpersonationContext impersonationContext = null;

            if (LogonUser(logon, domain, password, 2, 0, ref token) != 0)
            {
                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    impersonationContext = new WindowsIdentity(tokenDuplicate).Impersonate();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            //

            return (impersonationContext != null);
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LogonUser(string lpszUserName, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public extern static int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
    }
}
