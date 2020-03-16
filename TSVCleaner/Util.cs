using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TSVCleaner
{
    class Util
    {
        public static string removePunctuation(string sentence)
        {
            return Regex.Replace(sentence, @"[^\w]", string.Empty);
        }
        
        public static bool stringsAreIndentical(string firstString, string secondString)
        {
            firstString = firstString.ToLower();
            secondString = secondString.ToLower();
            if (firstString.Equals(secondString))
                return true;
            if (Util.removePunctuation(firstString).Equals(Util.removePunctuation(secondString))) //Check if pairs are identical without punctuation and whitespace
                return true;

            return false;
        }
    }
}
