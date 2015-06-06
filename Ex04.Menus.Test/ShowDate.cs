using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IRunOperation
    {
        public void RunOperation()
        {
            Console.WriteLine(DateTime.Now.ToString("d"));
            Console.WriteLine("\nPress 'enter' to continue");
            Console.ReadLine();
        }
    }
}
