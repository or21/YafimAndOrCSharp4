using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class ShowTime : Interfaces.IRunOperation
    {
        public void RunOperation()
        {
            MenuOperations.ShowTime(null);
        }
    }
}
