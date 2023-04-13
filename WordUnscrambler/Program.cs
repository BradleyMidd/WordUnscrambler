using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using WordUnscrambler.Data;
using WordUnscrambler.include;
using WordUnscrambler.Include;

namespace WordUnscrambler
{
    public class Program
    {

        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        

        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do 
                { 
                    Console.WriteLine(ConstantsStuff.OptionEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper()) 
                    {
                        case ConstantsStuff.File:
                            Console.Write(ConstantsStuff.EnterViaFile);
                            ExecuteInFile();
                            break;
                        case ConstantsStuff.Manual:
                            Console.Write(ConstantsStuff.EnterManually);
                            ExecuteManually();
                            break;
                        default:
                            Console.WriteLine(ConstantsStuff.OptionNotRecognized);
                            break;

                    }

                    var continueDecision = string.Empty;
                    do 
                    {
                        Console.WriteLine(ConstantsStuff.OptionContinueProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);

                    } while (!continueDecision.Equals(ConstantsStuff.Yes, StringComparison.OrdinalIgnoreCase) && !continueDecision.Equals(ConstantsStuff.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(ConstantsStuff.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstantsStuff.ErrorProgramTerminated + ex.Message);
            }

        }

        private static void ExecuteManually()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = manualInput.Split(',');
            DisplayMatchedWords(scrambleWords);
        }

        private static void ExecuteInFile()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambleWords = _fileReader.Read(filename);
                DisplayMatchedWords(scrambleWords);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ConstantsStuff.ErrorLoaded + ex.Message);
            }
        }
        private static void DisplayMatchedWords(string[] scrambleWords)
        {
            string[] wordList = _fileReader.Read(ConstantsStuff.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(ConstantsStuff.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else 
            {
                Console.WriteLine(ConstantsStuff.MatchNotFound);
            }
        }

    }
}