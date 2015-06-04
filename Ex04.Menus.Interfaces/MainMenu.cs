﻿using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private List<MainMenuItem> m_MainMenuList;
        private string m_Name;

        public MainMenu(string i_Name)
        {
            m_MainMenuList = new List<MainMenuItem>();
            m_Name = i_Name;
            MainMenuItem exitItem = new MainMenuItem();
            exitItem.Name = "Exit";
            exitItem.Item = new ExitOperation();
            m_MainMenuList.Add(exitItem);
        }

        public void AddSubMenu(string i_Name, object i_SubMenu)
        {
            MainMenuItem newItem = new MainMenuItem();
            newItem.Name = i_Name;
            newItem.Item = i_SubMenu;

            MainMenuItem backItem = new MainMenuItem();
            backItem.Name = "Back";
            backItem.Item = new BackOperation();

            MainMenu mainMenu = i_SubMenu as MainMenu;
            if (mainMenu != null)
            {
                mainMenu.m_MainMenuList[0] = backItem;
            }

            m_MainMenuList.Add(newItem);
        }

        public void RemoveSubMenu(string i_Name)
        {
            foreach (MainMenuItem currItem in m_MainMenuList)
            {
                bool isItemToDelete = i_Name == currItem.Name;
                if (isItemToDelete)
                {
                    m_MainMenuList.Remove(currItem);
                    break;
                }
            }
        }

        public void Show()
        {
            int operationChosen = 1;
            while (operationChosen != 0)
            {
                Console.Clear();
                Console.WriteLine(this.Name);
                int i = 0;
                foreach (MainMenuItem currItem in m_MainMenuList)
                {
                    Console.WriteLine(@"{0}: {1}", i, currItem.Name);
                    i++;
                }

                Console.WriteLine("\nPlease choose one of the options above or '{0}'", m_MainMenuList[0].Name);
                string answer = Console.ReadLine();
                bool isValidAnswer = checkInput(answer, out operationChosen);
                if (isValidAnswer)
                {
                    bool isMenu = m_MainMenuList[operationChosen].Item is MainMenu;
                    bool isOperation = m_MainMenuList[operationChosen].Item is IRunOperation;
                    if (isMenu)
                    {
                        ((MainMenu)m_MainMenuList[operationChosen].Item).Show();
                    }
                    else if (isOperation)
                    {
                        ((IRunOperation)m_MainMenuList[operationChosen].Item).RunOperation();
                    }
                    else
                    {
                        Console.WriteLine("Can't handle this choise. (Press 'enter' to continue)");
                        Console.ReadLine();
                    }
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

            return isValid;
        }

        private struct MainMenuItem
        {
            private string m_Name;
            private object m_Item;

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

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }
}
