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
            ui.Message("\n\n\n\n");

            while(!b.Over)
            {
                int piece;
                Position piecePos;

                // Prints round info and board
                ui.NewRoundMsg(b.turn, b.NextTurn);
                ui.ShowBoard(b);

                // Asks player which piece he wants to move
                piece = ui.PlayerPicks(b.NextTurn);
                piecePos = BoardPosition(piece);

                // Validates piece
                if (!b.ValidatePiece(piecePos))
                {
                    // Piece not valid, cycle restarts
                    ui.Message("Invalid choice. You can only grab your " +
                    "own pieces.");
                }
                else
                {
                    ////// DEBUG LINE
                    ui.Message("Piece Validated.");
                    
                    
                    // Asks player where he wants to move it

                    // Validates/makes move

                }
            }

            // Prints board
            ui.ShowBoard(b);

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