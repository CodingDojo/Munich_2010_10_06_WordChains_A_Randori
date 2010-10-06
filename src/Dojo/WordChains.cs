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
            var mutations = new List<string>();
            mutations.Add(startWord);
            if (this.IsValidMutation(startWord, endWord))
            {
                mutations.Add(endWord);
                return mutations;
            }
            else
            {
                mutations.Add("AB");
                mutations.Add(endWord);
                return mutations;
            }
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