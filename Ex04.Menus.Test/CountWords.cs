//-----------------------------------------------------------------------
// <copyright file="CountWords.cs" company="B15_Ex04">
// Yafim Vodkov 308973882 Or Brand 302521034
// </copyright>
//----------------------------------------------------------------------

namespace Ex04.Menus.Test
{
    /// <summary>
    /// CountWords class.
    /// </summary>
    public class CountWords : Interfaces.IRunOperation
    {
        /// <summary>
        /// Count words operation.
        /// </summary>
        public void RunOperation()
        {
            MenuOperations.CountWords(null);
        }
    }
}
