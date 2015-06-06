using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu myMenu = new MainMenu("Welcome to interfaces implemetation");
            MainMenu showDateTime = new MainMenu("Show Date/Time");
            MainMenu info = new MainMenu("Info");
            
            IRunOperation showTimeOperation = new ShowTime();
            IRunOperation showDateOperation = new ShowDate();
            IRunOperation showVersionOperation = new ShowVersion();
            IRunOperation countWordsOperation = new CountWords();

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
