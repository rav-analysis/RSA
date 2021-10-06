using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace RSA
{
    public class Crypt
    {
        public byte[] AsymmetricEncrypt(byte[] data)
        {
            return _rsa.Encrypt(data, false);
        }
        private readonly RSACryptoServiceProvider _rsa = new();

        public void SetPublicKey(string publicKeyFile)
        {
            var publicKey = File.ReadAllText(publicKeyFile);
            _rsa.ImportFromPem(publicKey);
        }
        public byte[] AsymmetricDecrypt(byte[] data)
        {
            return _rsa.Decrypt(data, false);
        }

        public void SetPrivateKey(string privateKeyFile)
        {
            var privateKey = File.ReadAllText(privateKeyFile);
            _rsa.ImportFromPem(privateKey);
        }
    }
    
}
