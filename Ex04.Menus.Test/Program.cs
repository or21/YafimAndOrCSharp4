using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
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

            Delegates.MainMenu myMenuDelegates = new Delegates.MainMenu("Welcome to Delegates implemetation");
            Delegates.MainMenu showDateTimeDelegates = new Delegates.MainMenu("Show Date/Time");
            Delegates.MainMenu infoDelegates = new Delegates.MainMenu("Info");

            Delegates.IRunOperation showTimeOperationDelegates = new ShowTime();
            Delegates.IRunOperation showDateOperationDelegates = new ShowDate();
            Delegates.IRunOperation showVersionOperationDelegates = new ShowVersion();
            Delegates.IRunOperation countWordsOperationDelegates = new CountWords();

            showDateTimeDelegates.AddSubMenu("Show Time", showTimeOperationDelegates);
            showDateTimeDelegates.AddSubMenu("Show Date", showDateOperationDelegates);

            infoDelegates.AddSubMenu("Show Version", showVersionOperationDelegates);
            infoDelegates.AddSubMenu("Count Words", countWordsOperationDelegates);

            myMenuDelegates.AddSubMenu(showDateTimeDelegates.Name, showDateTimeDelegates);
            myMenuDelegates.AddSubMenu(infoDelegates.Name, infoDelegates);

            myMenuDelegates.Show();
        }
    }
}
