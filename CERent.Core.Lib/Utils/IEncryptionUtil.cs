using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.Utils
{
    public interface IEncryptionUtil
    {
        public string Encrypt(string plainText);

        public string Decrypt(string ciperText);

    }
}
