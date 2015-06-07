using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        private readonly List<MenuItem> m_MainMenuList;
        private string m_Name;

        public MainMenu(string i_Name)
        {
            m_MainMenuList = new List<MenuItem>();
            m_Name = i_Name;

            MenuItem exitItem = new MenuItem(k_Exit, null);
            m_MainMenuList.Add(exitItem);
        }

        public void AddSubMenu(string i_Name, object i_SubMenu)
        {
            MenuItem newItem = new MenuItem(i_Name, i_SubMenu);

            MenuItem backItem = new MenuItem(k_Back, null);

            MainMenu mainMenu = i_SubMenu as MainMenu;
            if (mainMenu != null)
            {
                mainMenu.m_MainMenuList[0] = backItem;
            }

            MenuItem menuItem = i_SubMenu as MenuItem;
            m_MainMenuList.Add(menuItem ?? newItem);
        }

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

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }

    public class MenuItem
    {
        private string m_Name;
        private object m_Item;

        public MenuItem(string i_Name, object i_Item)
        {
            this.Name = i_Name;
            this.Item = i_Item;
        }

        public void ItemMenuClicked()
        {
            MainMenu toCompareTo = Item as MainMenu;

            if (toCompareTo != null)
            {
                ((MainMenu)Item).Show();
            }
            else
            {
                OnClicked();
            }
        }

        public event Action<MenuItem> Clicked;

        /// <summary>
        /// Runs a delagate
        /// </summary>
        protected virtual void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke(this);
            }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public object Item
        {
            get { return m_Item; }
            set { m_Item = value; }
        }
    }
}