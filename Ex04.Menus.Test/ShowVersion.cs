//-----------------------------------------------------------------------
// <copyright file="ShowVersion.cs" company="B15_Ex04">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------

namespace Ex04.Menus.Test
{
    /// <summary>
    /// Implements IRunOperation.
    /// </summary>
    public class ShowVersion : Interfaces.IRunOperation
    {
        /// <summary>
        /// Show version operation.
        /// </summary>
        public void RunOperation()
        {
            MenuOperations.ShowVersion(null);
        }
    }
}
