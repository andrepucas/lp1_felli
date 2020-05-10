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
                int button;
                Position buttonPos;

                // Prints board
                ui.ShowBoard(b);

                // Asks player which button he wants to move
                button = ui.PlayerPicks(b.NextTurn);
                buttonPos = BoardPosition(button);

                // Asks player where he wants to move it

                // Moves button
            }

            // Prints board

            // Final Results
        }

        private Position BoardPosition(int newMove)
        {
            switch (newMove)
            {
                case 1:     return new Position(0, 0);
                case 2:     return new Position(0, 4);
                case 3:     return new Position(0, 8);
                case 4:     return new Position(2, 2);
                case 5:     return new Position(2, 4);
                case 6:     return new Position(2, 6);
                case 7:     return new Position(4, 4);
                case 8:     return new Position(6, 2);
                case 9:     return new Position(6, 4);
                case 10:    return new Position(6, 6);
                case 11:    return new Position(8, 0);
                case 12:    return new Position(8, 4);
                case 13:    return new Position(8, 8);
                default:    return null;
            }
        }
    }
}