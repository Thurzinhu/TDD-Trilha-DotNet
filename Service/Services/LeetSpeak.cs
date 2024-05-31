using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LeetSpeak
    {
        public static string VowelsToNumbers(string s)
        {
            Dictionary<char, char> leetDict = 
            new Dictionary<char, char> { { 'a', '4' }, { 'e', '3' }, { 'i', '1' }, { 'o', '0' }, { 'u', '7' } };

            string leetSpeak = "";

            foreach (var letter in s)
            {
                if (leetDict.ContainsKey(char.ToLower(letter)))
                {
                    leetSpeak += leetDict[char.ToLower(letter)];
                }
                else
                {
                    leetSpeak += letter;
                }
            }

            return leetSpeak;
        }
    }
}