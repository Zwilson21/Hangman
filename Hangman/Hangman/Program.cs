using Hangman;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_Game

{ 
    internal class Program
   {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to Hangman! You have SEVEN(7) chances to guess the mystery word");
            string YesNo = string.Empty;
            do
            {
                Console.WriteLine();
                YesNo = PlayGame();
            }
            while (YesNo.ToUpper().Equals("Y"));
        }
        static void MakeTextBlink(string text, int delay)
        {
            for (int i = 0; i < 5; i++)
            {
                writeBlinkingText(text, delay, true);
                writeBlinkingText(text, 500, false);
            }
        }

        private static void writeBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);
        }

        private static string PlayGame()
        {
            WordList words = new();
            Word goalWord = words.PickGoalWord;
            PlayHangman playHangman = new PlayHangman();
            playHangman.PickedWord = goalWord;
            ConsoleKeyInfo yesNo = new();
            for (int i = 0; i < goalWord.Wordlength; i++)
            {
                Console.Write(" _ ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            while (playHangman.Result() == GameResult.CONTINUE)
            {
                Console.Write("Pick a Letter --> ");
                ConsoleKeyInfo guessedLetter = Console.ReadKey();
                if (playHangman.addGuessedLetter(guessedLetter.KeyChar))
                {
                    playHangman.Play();
                }
            }
            if (playHangman.Result() == GameResult.LOSE)
            {
                Console.WriteLine("Sorry, you struck out!");
                MakeTextBlink("The mystery word was: '" + goalWord.Content.ToUpper() + "'",500);
                
                Console.WriteLine("Do you want to play again? Y/N");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
            else
            {
                MakeTextBlink("Congratulations, you won!", 500);

                Console.WriteLine("Do you want to play again? Y/N");
                yesNo = Console.ReadKey();
                return yesNo.KeyChar.ToString();
            }
        }
    }
}