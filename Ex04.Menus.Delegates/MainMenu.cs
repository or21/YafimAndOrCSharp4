using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    /// <summary>
    /// Delegates class.
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Exit message
        /// </summary>
        private const string k_Exit = "Exit";

        /// <summary>
        /// Back message
        /// </summary>
        private const string k_Back = "Back";

        /// <summary>
        /// Holds the main menu items.
        /// </summary>
        private readonly List<MenuItem> m_MainMenuList;

        /// <summary>
        /// Name of the menu.
        /// </summary>
        private string m_Name;

        /// <summary>
        /// Initializes a new instance of the MainMenu class.
        /// </summary>
        /// <param name="i_Name">Name to set</param>
        public MainMenu(string i_Name)
        {
            m_MainMenuList = new List<MenuItem>();
            m_Name = i_Name;

            MenuItem exitItem = new MenuItem(k_Exit, null);
            m_MainMenuList.Add(exitItem);
        }

        /// <summary>
        /// Add sub-menu to current main menu.
        /// </summary>
        /// <param name="i_Name">Name of the sub-menu</param>
        /// <param name="i_SubMenu">The sub-menu to add</param>
        public void AddSubMenu(string i_Name, object i_SubMenu)
        {
            MenuItem newItem = new MenuItem(i_Name, i_SubMenu);
            MenuItem backItem = new MenuItem(k_Back, null);
            MainMenu mainMenu = i_SubMenu as MainMenu;
            MenuItem menuItem = i_SubMenu as MenuItem;

            if (mainMenu != null)
            {
                mainMenu.m_MainMenuList[0] = backItem;
            }

            m_MainMenuList.Add(menuItem ?? newItem);
        }

        /// <summary>
        /// Shows the current main menu level.
        /// </summary>
        public void Show()
        {
            int operationChosen = 1;

            while (operationChosen != 0)
            {
                Console.Clear();
                Console.WriteLine(this.Name);
                int i = 0;
                foreach (MenuItem currItem in m_MainMenuList)
                {
                    Console.WriteLine(@"{0}: {1}", i, currItem.Name);
                    i++;
                }

                Console.WriteLine("\nPlease choose one of the options above or '{0}'", m_MainMenuList[0].Name);
                string answer = Console.ReadLine();
                bool isValidAnswer = checkInput(answer, out operationChosen);
                if (isValidAnswer)
                {
                    m_MainMenuList[operationChosen].ItemMenuClicked();
                }
                else
                {
                    Console.WriteLine("Invalid choise. Please try again (Press 'enter' to continue)");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Validiates the input.
        /// </summary>
        /// <param name="i_Input">Input to check</param>
        /// <param name="o_Result">Parse result</param>
        /// <returns>If valid input</returns>
        private bool checkInput(string i_Input, out int o_Result)
        {
            bool isValid = false;
            bool validNumber = int.TryParse(i_Input, out o_Result);

            if (validNumber)
            {
                isValid = o_Result >= 0 && o_Result < m_MainMenuList.Count;
            }
            else
            {
                o_Result = -1;
            }

            return isValid;
        }

        /// <summary>
        /// Gets of sets menu's name.
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }
}