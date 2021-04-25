using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.Utils
{
    public class EncryptionUtil : IEncryptionUtil
    {
        public string Decrypt(string ciperText)
        {
            return ciperText;
        }

        public string Encrypt(string plainText)
        {
            return plainText;
        }
    }
}
