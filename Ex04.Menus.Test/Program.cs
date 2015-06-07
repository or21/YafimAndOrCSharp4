﻿namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runInterfacesMenu();

            runDelegatesMenu();
        }

        private static void runDelegatesMenu()
        {
            Delegates.MainMenu myMenu = new Delegates.MainMenu("Welcome to Delegates implemetation");
            Delegates.MainMenu showDateTime = new Delegates.MainMenu("Show Date/Time");
            Delegates.MainMenu info = new Delegates.MainMenu("Info");

            Delegates.MenuItem showDate = new Delegates.MenuItem("Show Date", null);
            showDate.Clicked += MenuOperations.ShowDate;

            Delegates.MenuItem showTime = new Delegates.MenuItem("Show Time", null);
            showTime.Clicked += MenuOperations.ShowTime;

            Delegates.MenuItem countWords = new Delegates.MenuItem("Count Words", null);
            countWords.Clicked += MenuOperations.CountWords;

            Delegates.MenuItem showVersion = new Delegates.MenuItem("Show Version", null);
            showVersion.Clicked += MenuOperations.ShowVersion;

            showDateTime.AddSubMenu(showDate.Name, showDate);
            showDateTime.AddSubMenu(showTime.Name, showTime);
            info.AddSubMenu(showVersion.Name, showVersion);
            info.AddSubMenu(countWords.Name, countWords);
            myMenu.AddSubMenu(showDateTime.Name, showDateTime);
            myMenu.AddSubMenu(info.Name, info);

            myMenu.Show();
        }

        private static void runInterfacesMenu()
        {
            Interfaces.MainMenu myMenu = new Interfaces.MainMenu("Welcome to Interfaces implemetation");
            Interfaces.MainMenu showDateTime = new Interfaces.MainMenu("Show Date/Time");
            Interfaces.MainMenu info = new Interfaces.MainMenu("Info");

            Interfaces.IRunOperation showTimeOperation = new ShowTime();
            Interfaces.IRunOperation showDateOperation = new ShowDate();
            Interfaces.IRunOperation showVersionOperation = new ShowVersion();
            Interfaces.IRunOperation countWordsOperation = new CountWords();

            showDateTime.AddSubMenu("Show Time", showTimeOperation);
            showDateTime.AddSubMenu("Show Date", showDateOperation);

            info.AddSubMenu("Show Version", showVersionOperation);
            info.AddSubMenu("Count Words", countWordsOperation);

            myMenu.AddSubMenu(showDateTime.Name, showDateTime);
            myMenu.AddSubMenu(info.Name, info);

            myMenu.Show();
        }
    }
}
