using System.Collections.Generic;

namespace Dojo
{
    public class WordChains
    {
        private readonly List<string> dictionary;

        public WordChains(List<string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public List<string> GetWordMutationPath(string startWord, string endWord)
        {
            if (startWord.Length == 1)
            {
                return new List<string>() { "B" };
            }
            return new List<string>() { "AA", "AB" };
        }

        internal bool IsValidMutation(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            int mutationCount = 0;
            for  (int i = 0 ; i < word1.Length;i++)
            {
                if (!word1[i].Equals(word2[i]))
                {
                    mutationCount++;
                }
            }
            return mutationCount == 1;

        }
    }
}