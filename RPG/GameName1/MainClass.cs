#region Using Statements
using AgetotonRPG;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GameName1
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameScreen())
                game.Run();
        }
    }
#endif
}
