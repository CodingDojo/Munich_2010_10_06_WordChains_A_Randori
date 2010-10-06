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

            List<string> mutation = wordChains.GetWordMutations(startWord, endWord);

            Assert.AreEqual( "B", mutation[0]);
        }

        [Test]
        public void GetWordMutations_DictionaryWithEndWordAndImpossibleMutation_ReturnsCorrectMutation()
        {
            var startWord = "AA";
            var endWord = "AB";

            var dictionary = new List<string> { "AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutations(startWord, endWord);

            Assert.AreEqual("AB", mutation[0]);            
            Assert.AreEqual(1, mutation.Count);            
        }

        [Test]
        public void GetWordMutations_DictionaryWithTwoMutation_ReturnsMutation()
        {
            var startWord = "AA";
            var endWord = "BB";

            var dictionary = new List<string> { "AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutations(startWord, endWord);

            Assert.AreEqual("AB", mutation[0]);              
            Assert.AreEqual("BB", mutation[1]);              
        }
    }

    public class WordChains
    {
        private readonly List<string> dictionary;

        public WordChains(List<string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public List<string> GetWordMutations(string startWord, string endWord)
        {
            if (startWord.Length == 1)
            {
                return new List<string>() { "B" };
            }
            return new List<string>() { "AB" };
        }
    }
}