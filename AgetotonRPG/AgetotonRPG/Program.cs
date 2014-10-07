﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using AgetotonRPG.Characters;
#endregion

namespace AgetotonRPG
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
            PaladinHero pesho = new PaladinHero(12, 3, 5);
            Console.WriteLine(pesho.Magic);
        }
    }
#endif
}
