using System;
using System.Globalization;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private const int nKEY = 3;
        private bool _IsCrypt = true;

        public char LogicalCrypt(char letter, int key)
        {            
            if (!char.IsLetter(letter) || char.IsWhiteSpace(letter))
            {
                return letter;
            }

            var acentos = "ÇÁÀÂÃÄÉÈÊËÍÌÎÏÓÒÔÕÖÚÙÛÜçáàâãäéèêëíìîïóòôõöúùûü";
            if (acentos.IndexOf(letter) != -1)
                throw new ArgumentOutOfRangeException();

            char d = char.IsUpper(letter) ? 'A' : 'a';            
            return (char)((((letter + key) - d) % 26) + d);
        }
        
        public string CryptMessage(string message)
        {
            string output = string.Empty;
            int _key = nKEY;
            if (!_IsCrypt)
            {
                _key = 26 - nKEY;
            }

            foreach (char ch in message)
              output += LogicalCrypt(ch, _key);

            return output;
        }
        
        public string Crypt(string message)
        {
            string output;               

            if(message == string.Empty)
            {
                output = message;
            }
            else
            if (!string.IsNullOrEmpty(message))
            {
                output = CryptMessage(message.ToLower());
            }
            else
                throw new ArgumentNullException();

            return output;
        }

        public string Decrypt(string cryptedMessage)
        {
            _IsCrypt = false;
            return Crypt(cryptedMessage);
        }
    }
}
