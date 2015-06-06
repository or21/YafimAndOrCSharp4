using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IRunOperation
    {
        public void RunOperation()
        {
            Console.WriteLine("Current time is: {0}", DateTime.Now.ToString("T"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }
    }
}
