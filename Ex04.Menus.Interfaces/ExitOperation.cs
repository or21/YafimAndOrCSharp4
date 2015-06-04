using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ExitOperation : IRunOperation
    {
        public void RunOperation()
        {
            Environment.Exit(1);
        }
    }
}
