using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.include;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.include.Tests
{
    [TestClass()]
    public class WordMatcherTests
    {
        private readonly WordMatcher _matcher = new WordMatcher();

        [TestMethod()]
        public void ScrambledWordMatchesGivenWordInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre" };

            var matchedWords = _matcher.Match(scrambledWords, words);

            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        }        
        
        [TestMethod()]
        public void ScrambledWordMatchesGivenWordsInTheList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre", "act" };

            var matchedWords = _matcher.Match(scrambledWords, words);

            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));            
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.IsTrue(matchedWords[1].Word.Equals("cat"));
        }
    }
}