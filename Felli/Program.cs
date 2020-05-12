using System;

namespace Felli
{
    class Program
    {
        /// <summary>
        /// Directs the players to the intro screen and starts the game.
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
