using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("SomeAsembly")]
namespace Algorithms.StringSearching
{
    public class BoyerMooreHorspool
    {
        public bool IsPresent(string paragraph, string word)
        {
            word = word.ToLower();
            paragraph = paragraph.ToLower();
            if (word.Length > paragraph.Length)
            {
                return false;
            }

            Dictionary<char, int> badMatchTable = CreateBadMatchTable(word);

            var wordLastIndex = word.Length - 1;
            var numberOfPlacesToSkip = word.Length; // Number of places to shift should be equal to length
            var i = wordLastIndex;
            var j = wordLastIndex;

            while (j <= paragraph.Length - 1)
            {
                //do we have a match
                if (paragraph[j] == word[i])
                {
                    var temp = j;
                    while (i >= 0 && word[i] == paragraph[temp])
                    {
                        --i;
                        --temp;
                    }

                    //We have a match
                    if (i == -1)
                    {
                        return true;
                    }
                }
                //does the item exists in the bad match table
                if (badMatchTable.TryGetValue(paragraph[j], out var charIndex))
                {
                    j = j + charIndex;
                }
                else
                {
                    j = j + numberOfPlacesToSkip;
                }

                //reset i
                i = wordLastIndex;
            }

            return false;
        }

        internal Dictionary<char, int> CreateBadMatchTable(string word)
        {
            //Important to skip the last index because the bad match table runs from
            //i to pattern.length - i - 1 and skips the last character in the string
            var dictionary = new Dictionary<char, int>();
            for (int i = word.Length - 2; i >= 0; i--)
            {
                if (!dictionary.ContainsKey(word[i]))
                {
                    dictionary.Add(word[i], word.Length - 1 - i);
                }
            }

            return dictionary;
        }
    }
}
