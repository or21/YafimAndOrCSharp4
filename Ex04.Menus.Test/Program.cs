using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu myMenu = new MainMenu("First Level. Welcome");
            MainMenu subMenu1 = new MainMenu("Sub Menu 1");
            MainMenu subMenu2 = new MainMenu("Sub Menu 2");
            MainMenu subMenu11 = new MainMenu("Sub Menu 11");
            MainMenu subMenu22 = new MainMenu("Sub Menu 22");
            IRunOperation print1 = new Print1();
            IRunOperation print2 = new Print2();

            subMenu22.AddSubMenu("print 2 second level", print2);
            subMenu2.AddSubMenu(subMenu22.Name, subMenu22);
            subMenu2.AddSubMenu("Print 2 first level", print2);

            subMenu11.AddSubMenu("print 1 second level", print1);
            subMenu1.AddSubMenu(subMenu11.Name, subMenu11);
            subMenu1.AddSubMenu("Print 1 first level", print1);

            myMenu.AddSubMenu(subMenu1.Name, subMenu1);
            myMenu.AddSubMenu(subMenu2.Name, subMenu2);

            myMenu.Show();
        }
    }
}
