using System;
using System.Text;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = args[0];
            var crypt = new Crypt();
            if (operation == "encrypt")
            {
                var publicKeyFile = args[1];
                crypt.SetPublicKey(publicKeyFile);

                var data = Encoding.UTF8.GetBytes(Console.In.ReadToEnd());
                var encryptedData = crypt.AsymmetricEncrypt(data);
                Console.WriteLine(System.Convert.ToBase64String(encryptedData));
            }
            else if (operation == "decrypt")
            {
                var privateKeyFile = args[1];
                crypt.SetPrivateKey(privateKeyFile);
                var encryptedData = System.Convert.FromBase64String(Console.In.ReadToEnd());
                var decryptedData = crypt.AsymmetricDecrypt(encryptedData);
                Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
            }
        }
    }
}
