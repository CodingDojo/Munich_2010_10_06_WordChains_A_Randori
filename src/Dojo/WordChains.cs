using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Dojo
{
    [TestFixture]
    public class WordChainsTests
    {
        [Test]
        public void GetWordMutation_DictionaryWithOnePossibleMutation_ReturnsMutation()
        {
            var startWord = "A";
            var endWord = "B";

            var dictionary = new List<string> { "B" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutation(startWord, endWord);

            Assert.AreEqual( "B", mutation[0]);
        }
    }

    public class WordChains
    {
        private readonly List<string> dictionary;

        public WordChains(List<string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public List<string> GetWordMutation(string startWord, string endWord)
        {
            return new List<string>() { "B" };
        }
    }
}