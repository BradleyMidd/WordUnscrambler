using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.Include
{
    public class ConstantsStuff
    {
        public const string OptionEnterScrambledWords = "Enter scrambled word(s) manually or as a file: F - file/M - Manual";
        public const string OptionContinueProgram = "Would you like to contine? Y/N";

        public const string EnterViaFile = "Enter full path including the file name: ";
        public const string EnterManually = "Enter word(s) manually (seperated by commas if multiple): ";
        public const string OptionNotRecognized = "The option was not recgonized.";

        public const string ErrorLoaded = "Scrambled words were not loaded, because there was an error: ";
        public const string ErrorProgramTerminated = "The program will be terminated: ";

        public const string MatchFound = "MATCH FOUND FOR {0}: {1}";
        public const string MatchNotFound = "NO MATCHED HAVE BEEN FOUND";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordListFileName = "wordlist.txt";


    }
}
