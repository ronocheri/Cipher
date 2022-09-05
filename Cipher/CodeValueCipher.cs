using System;
using System.Collections.Generic;
using System.Linq;

namespace Cipher
{
    public class CodeValueCipher : ICodeValueCipher
    {
        const char statingChar = 'A';
        const char endingChar = 'Z';

        
        public string Encrypt(string message, string key)
        {
            string res = "";

            Dictionary<char, char> dicRes = getDicEnc(message, key);

            for (int i = 0; i < message.Length; i++)
            {
                char ckey = message[i];
                res += dicRes[ckey];
            }
            return res;
        }

        public string Decrypt(string message, string key)
        {

            string res = "";
            Dictionary<char, char> dicRes = getDicEnc(message, key);

            for (int i = 0; i < message.Length; i++)
            {
                char cMes = message[i];
                var myKey = dicRes.FirstOrDefault(x => x.Value == cMes).Key;
                res += myKey;
            }

            return res;
        }



        public Dictionary<char,char> getDicEnc(string message, string key)
        {
            Dictionary<char, char> dicRes = new Dictionary<char, char>();
            for (int i = 0; i < key.Length; i++)
            {
                char ckey = key[i];
                dicRes.Add((char)(statingChar + i), ckey);
            }
            return dicRes;
        }


    }
}
