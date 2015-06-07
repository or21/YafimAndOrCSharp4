using System;

namespace Ex04.Menus.Delegates
{
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