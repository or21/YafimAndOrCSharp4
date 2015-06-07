using System;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class ShowDate : Interfaces.IRunOperation
    {
        public void RunOperation()
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("d"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }
    }
}
