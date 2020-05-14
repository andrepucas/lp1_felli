using System;

namespace Felli
{
    /// <summary>
    /// Main <c>Program</c> Class.
    /// Contains a single method that redirects the players.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Calls in the intro screen, followed by the game loop (Start).
        /// </summary>
        static void Main(string[] args)
        {   
            UserInterface ui = new UserInterface();
            ui.Intro();

            Game game = new Game();
            game.Start();
        }
    }
}
