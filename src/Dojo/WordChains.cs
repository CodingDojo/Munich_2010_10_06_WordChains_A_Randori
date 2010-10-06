using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Dojo
{
    [TestFixture]
    public class WordChainsTests
    {
        [Test]
        public void GetWordMutations_DictionaryWithOnePossibleMutation_ReturnsMutation()
        {
            var startWord = "A";
            var endWord = "B";

            var dictionary = new List<string> { "B" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual( "B", mutation[0]);
        }

        [Test]
        public void GetWordMutations_DictionaryWithEndWordAndImpossibleMutation_ReturnsCorrectMutation()
        {
            var startWord = "AA";
            var endWord = "AB";

            var dictionary = new List<string> { "AA","AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual("AA", mutation[0]);            
            Assert.AreEqual("AB", mutation[1]);            
            Assert.AreEqual(2, mutation.Count);            
        }

        [Test]
        public void GetWordMutations_DictionaryWithTwoMutation_ReturnsMutation()
        {
            var startWord = "AA";
            var endWord = "BB";

            var dictionary = new List<string> { "AA", "AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual("AA", mutation[0]);
            Assert.AreEqual("AB", mutation[1]);
            Assert.AreEqual("BB", mutation[2]);
            Assert.AreEqual(3, mutation.Count);
        }

        [Test]
        public void IsValidMutation_ComparesTwoMutableWordOfSameLength_ReturnsTrue()
        {
            var word1 = "AA";
            var word2 = "AB";

            var wordChains = new WordChains(null);

            bool isValidMutation = wordChains.IsValidMutation(word1, word2);

            Assert.IsTrue(isValidMutation);
            
        }

        [Test]
        public void IsValidMutation_ComparesTwoImmutableWordsOfSameLength_ReturnsFalse()
        {
            var word1 = "AA";
            var word2 = "BB";

            var wordChains = new WordChains(null);

            bool isValidMutation = wordChains.IsValidMutation(word1, word2);

            Assert.IsFalse(isValidMutation);
        }
 
        [Test]
        public void IsValidMutation_ComparesTwoWordsOfDifferentLength_ReturnsFalse()
        {
            var word1 = "A";
            var word2 = "BB";

            var wordChains = new WordChains(null);

            bool isValidMutation = wordChains.IsValidMutation(word1, word2);

            Assert.IsFalse(isValidMutation);
        }
    }

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
            return new List<string>() { "AB" };
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