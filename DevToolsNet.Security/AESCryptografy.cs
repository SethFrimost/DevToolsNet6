using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Security
{
    public class AESCryptography : IEncryption
    {
        private string key = null;

        public AESCryptography(string Key)
        {
            key = Key;
        }

        public string Decrypt(string data)
        {
            return Cryptography.AESDecryptData(data, key);
        }

        public string Encrypt(string data)
        {
            return Cryptography.AESEncryptData(data, key);
        }
    }
}
