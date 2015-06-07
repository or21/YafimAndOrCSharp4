using System;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class CountWords : Interfaces.IRunOperation
    {
        public void RunOperation()
        {
            MenuOperations.CountWords(null);
        }
    }
}
