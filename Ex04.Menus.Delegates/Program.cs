using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Program
    {
        public static void Main()
        {
            MainMenu myMenu = new MainMenu("Welcome to interfaces implemetation");
            MainMenu showDateTime = new MainMenu("Show Date/Time");
            MainMenu info = new MainMenu("Info");

            MenuItem showDate = new MenuItem("Show Date");
            showDate.Clicked += ShowDate;

            MenuItem showTime = new MenuItem("Show Time");
            showTime.Clicked += ShowTime;

            MenuItem countWords = new MenuItem("Count Words");
            countWords.Clicked += CountWords;

            MenuItem showVersion = new MenuItem("Show Version");
            showVersion.Clicked += ShowVersion;

            showDateTime.AddSubMenu(showDate.Name, showDate);
            showDateTime.AddSubMenu(showTime.Name, showTime);

            info.AddSubMenu(showVersion.Name, showVersion);
            info.AddSubMenu(countWords.Name, countWords);

            myMenu.AddSubMenu(showDateTime.Name, showDateTime);
            myMenu.AddSubMenu(info.Name, info);

            myMenu.Show();

        }


        /* The methods to do */

        public static void ShowDate(MenuItem menuItem)
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("d"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }

        public static void CountWords(MenuItem menuItem)
        {
            Console.WriteLine("Please enter a sentence and then press 'enter':");
            string inputFromUser = Console.ReadLine();
            if (inputFromUser != "")
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

        public static void ShowVersion(MenuItem menuItem)
        {
            Console.WriteLine("Version: 15.2.4.0");
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }


        public static void ShowTime(MenuItem menuItem)
        {
            Console.WriteLine("Current time is: {0}", DateTime.Now.ToString("T"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }

    }
}

