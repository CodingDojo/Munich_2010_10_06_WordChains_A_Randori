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

            var dictionary = new List<string> { "A", "B" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual( "A", mutation[0]);
            Assert.AreEqual( "B", mutation[1]);
        }

        [Test]
        public void GetWordMutations_DictionaryWithEndWordAndImpossibleMutation_ReturnsCorrectMutation()
        {
            var startWord = "AA";
            var endWord = "AB";

            var dictionary = new List<string> { "AA","AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual(2, mutation.Count);            
            Assert.AreEqual("AA", mutation[0]);            
            Assert.AreEqual("AB", mutation[1]);            
        }

        [Test]
        public void GetWordMutations_DictionaryWithTwoMutation_ReturnsMutation()
        {
            var startWord = "AA";
            var endWord = "BB";

            var dictionary = new List<string> { "AA", "AB", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual(3, mutation.Count);
            Assert.AreEqual("AA", mutation[0]);
            Assert.AreEqual("AB", mutation[1]);
            Assert.AreEqual("BB", mutation[2]);
        }

        [Test]
        public void GetWordMutations_DictionaryWithTwoMutationCaseBA_ReturnsMutation()
        {
            var startWord = "AA";
            var endWord = "BB";

            var dictionary = new List<string> { "AA", "BA", "BB" };
            var wordChains = new WordChains(dictionary);

            List<string> mutation = wordChains.GetWordMutationPath(startWord, endWord);

            Assert.AreEqual(3, mutation.Count);
            Assert.AreEqual("AA", mutation[0]);
            Assert.AreEqual("BA", mutation[1]);
            Assert.AreEqual("BB", mutation[2]);
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
}