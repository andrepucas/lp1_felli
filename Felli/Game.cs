using System;

namespace Felli
{
    /// <summary>
    /// <c>Game</c> Class.
    /// Contains the game loop and other auxiliar game methods.
    /// </summary>
    public class Game
    {
        private Board b;
        private UserInterface ui;

        /// <summary>
        /// <c>Game</c> Constructor.
        /// Creates a new <c>Board</c> (b) and <c>UserInterface</c> (ui).
        /// </summary>
        public Game()
        {
            b = new Board();
            ui = new UserInterface();
        }
        
        /// <summary>
        /// Distances the intro, asks users their preferences and runs 
        /// the game loop.
        /// </summary>
        public void Start()
        {
            // "Console.Clear()"
            ui.Message("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            ui.Message("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            ui.Message("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            // Calls method that asks players what colors and turns they want.
            // Returns an integer 'turn' value (0/1) depending on the results.
            b.turn = ui.GetTurn();

            // Game Loop, ends when b.Over returns true.
            while(!b.Over)
            {
                // Ref = Integer Board reference (1-13).
                // Pos = Board Coordinates (row, col).
                int pieceRef, moveToRef;
                Position piecePos, movePos;

                // Prints updated round info and board.
                ui.NewRoundMsg(b.turn, b.NextTurn);
                ui.ShowBoard(b);

                // Asks player which piece he wants to move.
                pieceRef = ui.PlayerPicks(b.NextTurn);
                piecePos = BoardPosition(pieceRef);

                // Validates piece picked.
                if (!b.ValidatePiece(piecePos))
                {
                    // Piece not valid, cycle restarts
                    ui.Message("||  Invalid choice. You can only grab your " +
                    "own pieces. Try again");
                }
                else
                {
                    // Asks player where he wants to move his piece.
                    moveToRef = ui.PlayerMoves(pieceRef, b.NextTurn);
                    movePos = BoardPosition(moveToRef);

                    // Validates/makes move.
                    if (b.ValidateMove(piecePos, movePos, pieceRef, moveToRef))
                    {   
                        // Feedback on moved piece.
                        ui.Message($"||  [Player {b.NextTurn}] has moved " +
                        $"piece from {pieceRef} to {moveToRef}");

                        // Increments turn.
                        b.turn++;
                    }
                    else
                    {  
                        // Move not valid, cycle restarts.
                        ui.Message("||  Invalid move. Try again");
                    }
                }
            }
            // Prints results and board.
            ui.WinBox(b.Winner, b.turn);
            ui.ShowBoard(b);
        }

        /// <summary>
        /// Converts board reference to matrix board position.
        /// </summary>
        /// <param name="reference">Integer Board reference (1-13)</param>
        /// <returns>Board Coordinates of the position.(row, col).</returns>
        private Position BoardPosition(int reference)
        {
            switch (reference)
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