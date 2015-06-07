using System;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class ShowDate : Interfaces.IRunOperation
    {
        public void RunOperation()
        {
            MenuOperations.ShowDate(null);
        }
    }
}
