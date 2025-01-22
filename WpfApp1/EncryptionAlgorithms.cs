using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class EncryptionAlgorithms
    {
        private static string abc_ru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string Ceasar(string key, string code)
        {
            if (!int.TryParse(key, out int int_key))
                return null;

            string result = "";
            code = code.ToLower();

            for (int i = 0; i < code.Length; i++)
            {
                if (abc_ru.IndexOf(code[i]) == -1)
                {
                    result += code[i]; 
                    continue;
                }
                result += abc_ru[((abc_ru.IndexOf(code[i]) + int_key) % 33)];
            }

            return result;
        }

        public static string De_Ceaser(string key, string code)
        {
            if (!int.TryParse(key, out int int_key))
                return null;

            string result = "";
            code = code.ToLower();

            for (int i = 0; i < code.Length; i++)
            {
                int index = abc_ru.IndexOf(code[i]);

                if (index == -1)
                {
                    result += code[i];
                }
                else
                {
                    int newIndex = (index - int_key % 33 + 33) % 33;
                    result += abc_ru[newIndex];
                }
            }

            return result;
        }


        public static string vibor(string key, string code, bool vibor)
        {
            if (vibor)
               return Ceasar(key, code);
            else
                return De_Ceaser(key, code);
        }
    }
}
