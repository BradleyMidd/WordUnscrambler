using WordUnscrambler.Data;

namespace WordUnscrambler.include
{
    public class WordMatcher
    {

        public List<MatchedWord> Match(string[] scrambleWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambleWord in scrambleWords) 
            { 
                foreach (var word in wordList) 
                {
                    if (scrambleWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambleWord, word));
                    }
                    else
                    { 
                        var scrambledWordArray = scrambleWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambleWord, word));
                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word) 
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}