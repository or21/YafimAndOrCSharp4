using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Print1 : IRunOperation
    {
        public void RunOperation()
        {
            Console.WriteLine("I'm printing 1");
            Console.ReadLine();
        }
    }
}
