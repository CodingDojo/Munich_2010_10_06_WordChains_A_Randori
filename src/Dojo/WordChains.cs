using System;
using System.Collections.Generic;
using System.Linq;

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
                mutations.Add(this.FindAllMutations(startWord).First());
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

        public List<string> FindAllMutations(string word)
        {
            return dictionary.Where(c => this.IsValidMutation(word, c)).ToList();
            
        }
    }
}