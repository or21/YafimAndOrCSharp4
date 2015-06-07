//-----------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="B15_Ex04">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------
using System;

namespace Ex04.Menus.Delegates
{
    /// <summary>
    /// MenuItem class.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Event to handle
        /// </summary>
        public event Action<MenuItem> Clicked;

        /// <summary>
        /// Name of the menu item
        /// </summary>
        private string m_Name;

        /// <summary>
        /// The menu item
        /// </summary>
        private object m_Item;

        /// <summary>
        /// Initializes a new instance of the MenuItem class.
        /// </summary>
        /// <param name="i_Name">The name to set</param>
        /// <param name="i_Item">The item to set</param>
        public MenuItem(string i_Name, object i_Item)
        {
            this.Name = i_Name;
            this.Item = i_Item;
        }

        /// <summary>
        /// Checks what operation to to do.
        /// </summary>
        public void menuItem_Clicked()
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

        /// <summary>
        /// Runs a delegate after triggered 
        /// </summary>
        protected virtual void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke(this);
            }
        }

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// Gets or sets the menu item.
        /// </summary>
        public object Item
        {
            get { return m_Item; }
            set { m_Item = value; }
        }
    }
}