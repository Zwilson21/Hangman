using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class PlayHangman
    {
        private Word _pickedWord;

        public Word PickedWord
        {
            get { return _pickedWord; }
            set { _pickedWord = value; }
        }
        private List<string> correctLetters;

        private List<string> guessedLetters;

        private List<string> incorrectLetters;

        public PlayHangman()
        {
            correctLetters = new List<string>();
            guessedLetters = new List<string>();
            incorrectLetters = new List<string>();
        }

        public void Play()
        {
            correctLetters = new List<string>();
            for (int i = 0; i < _pickedWord.Wordlength; i++)
            {
                correctLetters.Add(" _ ");
            }
            for (int i = 0; i < _pickedWord.Wordlength; i++)
            {
                string letter = _pickedWord.Content.Substring(i, 1);
                if (guessedLetters.Count > 0)
                {
                    foreach (string guessedLetter in this.guessedLetters)
                    {
                        if (letter.Equals(guessedLetter.Trim().ToUpper()))
                        {
                            correctLetters.RemoveAt(i);
                            correctLetters.Insert(i, " " + letter + " ");
                        }
                    }
                }
            }
            drawHangMan();
            Console.WriteLine(buildString(correctLetters, false));
            Console.WriteLine();
        }
        public bool addGuessedLetter(char letter)
        {
            if (!char.IsLetter(letter))
            {
                Console.WriteLine();
                Console.WriteLine("'" + letter.ToString().ToUpper() + "' is not a valid letter");
                return false;
            }
            else if (!this.guessedLetters.Contains(letter.ToString().ToUpper()))
            {
                this.guessedLetters.Add(letter.ToString().ToUpper());
                Console.WriteLine();
                Console.WriteLine("Guessed Letters: " + buildString(guessedLetters, true));
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sorry, you already guessed '" + letter.ToString().ToUpper() + "'!");
                return false;
            }
        }
        private bool checkLetter(string letter)
        {
            for (int i = 0; i < _pickedWord.Wordlength; i++)
            {
                string splitLetter = _pickedWord.Content.Substring(i, 1).ToUpper();
                if (letter.Equals(splitLetter.ToUpper())) 
                { 
                    return true; 
                }
            }
            return false;
        }

        private void drawHangMan()
        {
            incorrectLetters = new List<string>();
           foreach (string letter in this.guessedLetters)
            {
                if (!checkLetter(letter))
                {
                    incorrectLetters.Add(letter);
                }
            }

            Console.WriteLine();
            switch (incorrectLetters.Count)
            {
                case 0:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 1:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 2:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 3:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |   \\|");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    break;
                case 4:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |   \\|/");
                        Console.WriteLine("  |     ");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 5:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |   \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 6:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |   \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |    / ");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                        break;
                case 7:
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |   \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |    / \\");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    break;
            }
            Console.WriteLine();
        }

        private string buildString(List<string> inPutString, bool space)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in inPutString)
            {
                if (space)
                {
                    sb = sb.Append(item.ToString().ToUpper() + " ");
                }
                else
                {
                    sb = sb.Append(item.ToString().ToUpper());
                }
            }
            return sb.ToString();
        }
        public GameResult Result()
        {
            if (incorrectLetters.Count == 7)
            {
                return GameResult.LOSE;
            }
            else if (_pickedWord.Content.ToUpper().Equals(buildString(correctLetters, false).Replace(" ", "")))
            {
                return GameResult.WIN;
            }

            return GameResult.CONTINUE;
        }
    }
}
