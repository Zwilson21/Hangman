using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    internal class WordList : List<Word>
    {

        private List<Word> words = new List<Word>(10);

        StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, "WordList.txt"));

        public WordList() {
            try 
            { 
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(new Word(line));
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public Word PickGoalWord
        {
            get
            {
                Random rand = new Random();
                int index = (int)(rand.NextDouble() * 10);
                Word goalWord = words.ElementAt(index);
                goalWord.Content = goalWord.Content.ToUpper();
                return goalWord;
            }
        }

    }
}
