//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="B15_Ex04">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
namespace Ex04.Menus.Test
{
    /// <summary>
    /// Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the program
        /// </summary>
        public static void Main()
        {
            runInterfacesMenu();
            runDelegatesMenu();
        }

        /// <summary>
        /// Runs delegate version.
        /// </summary>
        private static void runDelegatesMenu()
        {
            Delegates.MainMenu myMenu = new Delegates.MainMenu("Welcome to Delegates implemetation");
            Delegates.MainMenu showDateTime = new Delegates.MainMenu("Show Date/Time");
            Delegates.MainMenu info = new Delegates.MainMenu("Info");

            Delegates.MenuItem showTime = new Delegates.MenuItem("Show Time", null);
            showTime.Clicked += MenuOperations.ShowTime;

            Delegates.MenuItem showDate = new Delegates.MenuItem("Show Date", null);
            showDate.Clicked += MenuOperations.ShowDate;

            Delegates.MenuItem countWords = new Delegates.MenuItem("Count Words", null);
            countWords.Clicked += MenuOperations.CountWords;

            Delegates.MenuItem showVersion = new Delegates.MenuItem("Show Version", null);
            showVersion.Clicked += MenuOperations.ShowVersion;

            showDateTime.AddSubMenu(showTime.Name, showTime);
            showDateTime.AddSubMenu(showDate.Name, showDate);
            info.AddSubMenu(showVersion.Name, showVersion);
            info.AddSubMenu(countWords.Name, countWords);
            myMenu.AddSubMenu(showDateTime.Name, showDateTime);
            myMenu.AddSubMenu(info.Name, info);

            myMenu.Show();
        }

        /// <summary>
        /// Runs Interface version.
        /// </summary>
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
