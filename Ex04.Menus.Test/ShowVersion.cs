using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IRunOperation
    {
        public void RunOperation()
        {
            Console.WriteLine("Version: 15.2.4.0");
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }
    }
}
