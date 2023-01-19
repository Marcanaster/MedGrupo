using Elskom.Generic.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedGrupo.CrossCutting.Helper
{
    public static class Crypt
    {
        public static string Encrypt(string item, string key)
        {
            BlowFish blowfish = new BlowFish(key);
            return blowfish.EncryptECB(item);
        }

        public static string Decrypt(string item, string Key)
        {
            BlowFish blowfish = new BlowFish(Key);
            return blowfish.DecryptECB(item);
        }
    }
}
