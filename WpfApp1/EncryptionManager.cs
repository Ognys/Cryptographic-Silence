using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class EncryptionManager
    {
        public delegate string EncryptionMethod(string key, string code, bool vibor);

        private Dictionary<string, EncryptionMethod> _encryptionManager;
        public static bool IsEncry { get; set; }
        public EncryptionManager()
        {
            _encryptionManager = new Dictionary<string, EncryptionMethod>()
            {
                {"Цезарь", EncryptionAlgorithms.vibor}
            };

        }

        public string ChoosingEncryption(string encryption,string key,string code)
        {
            if(!_encryptionManager.TryGetValue(encryption, out EncryptionMethod method))
                return null;

            return method(key,code,IsEncry);

        }
    }
}
