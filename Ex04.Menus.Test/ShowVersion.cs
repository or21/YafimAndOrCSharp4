﻿using System;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class ShowVersion : Interfaces.IRunOperation
    {
        public void RunOperation()
        {
            MenuOperations.ShowVersion(null);
        }
    }
}
