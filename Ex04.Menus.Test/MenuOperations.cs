using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class MenuOperations
    {
        public static void CountWords(MenuItem menuItem)
        {
            Console.WriteLine("Please enter a sentence and then press 'enter':");
            string inputFromUser = Console.ReadLine();
            if (inputFromUser != string.Empty)
            {
                int numberOfWords = countWordsInString(inputFromUser);
                Console.WriteLine("The number of words in your input is: {0}", numberOfWords);
                Console.WriteLine("\nPress 'enter' to continue");
            }
            else
            {
                Console.WriteLine("\nNot a valid sentence. Press 'enter' to continue");
            }

            Console.ReadLine();
        }

        private static int countWordsInString(string i_InputFromUser)
        {
            int numberOfSpaces = char.IsWhiteSpace(i_InputFromUser[i_InputFromUser.Length - 1]) ? 1 : 0;
            int numberOfWords = char.IsWhiteSpace(i_InputFromUser[0]) ? -1 : 0;
            for (int i = 1; i < i_InputFromUser.Length; i++)
            {
                if (char.IsWhiteSpace(i_InputFromUser[i - 1]))
                {
                    numberOfSpaces++;
                    bool isNotWhiteSpace = char.IsLetterOrDigit(i_InputFromUser[i]) ||
                                           char.IsPunctuation(i_InputFromUser[i]);
                    if (isNotWhiteSpace)
                    {
                        numberOfWords++;
                    }
                }
            }

            numberOfWords++;

            bool allStringIsSpaces = numberOfSpaces == i_InputFromUser.Length;
            if (allStringIsSpaces)
            {
                numberOfWords = 0;
            }

            return numberOfWords;
        }

        public static void ShowDate(MenuItem i_MenuItem)
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("d"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }

        public static void ShowTime(MenuItem i_MenuItem)
        {
            Console.WriteLine("Current time is: {0}", DateTime.Now.ToString("T"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }

        public static void ShowVersion(MenuItem i_MenuItem)
        {
            Console.WriteLine("Version: 15.2.4.0");
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }
    }
}
