using System;

namespace Felli
{
    public class Game
    {
        private Board b;
        private UserInterface ui;

        public Game()
        {
            b = new Board();
            ui = new UserInterface();
        }
        
        public void Start()
        {
            while(!b.Over)
            {
                // int userTurn;
        
                ui.intro();
                // userTurn = ui.getTurn();
                // Board.Turn(userTurn);
                ui.ShowBoard(b);

                // DEBUG: Serve só para parar o ciclo e ver board.
                Console.ReadLine();
            }
        }
    }
}