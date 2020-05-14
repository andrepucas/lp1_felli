namespace Felli
{
    /// <summary>
    /// <c>Board</c> Class.
    /// Contains all methods related with the board functioning.
    /// </summary>
    /// <remarks>
    /// This class will control who plays next, game loop duration, the board, 
    /// all pieces and their corresponding picking and moving rules.
    /// </remarks>
    public class Board
    {
        private State[,] state;
        public int turn;

        /// <summary>
        /// Controls which player plays next by returning a <c>State</c>.
        /// </summary>
        /// <value>Gets int value of turn.</value>
        public State NextTurn
        {
            get
            {
                if (turn % 2 == 0) return State.W;
                else return State.B;
            }
        }

        /// <summary>
        /// Controls the game loop.
        /// Game loop runs as long as there are no Winners.
        /// </summary>
        /// <value>Gets a <c>State</c> value of Winner.</value>
        public bool Over
        {
            get
            {
                // While != this returns true and the game continues.
                return Winner != State.Empty;
            }
        }

        /// <summary>
        /// Checks if any of the players have won yet.
        /// </summary>
        /// <value>Gets boolean value for each player.</value>
        public State Winner
        {
            get
            {
                if (HasWon(State.W)) return State.W;
                if (HasWon(State.B)) return State.B;
                
                // Default value if there are no winners.
                return State.Empty;
            }
        }

        /// <summary>
        /// Goes through the board and checks if there are any opponent 
        /// pieces left.
        /// </summary>
        /// <param name="player">State of the current player (B or W).</param>
        /// <returns>
        /// Boolean value, true if there are no more opponent pieces left.
        /// </returns>
        private bool HasWon(State player)
        {
            int countEnemy = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // [Player W] counting [Player B]'s pieces.
                    if (player == State.W && state[i, j] == State.B)
                    {
                        countEnemy++;
                    }

                    // [Player B] counting [Player W]'s pieces.
                    else if (player == State.B && state[i, j] == State.W)
                    {
                        countEnemy++;
                    }
                }
            }
            // Returns true if the opponent has no pieces.
            if (countEnemy == 0) return true;
            return false;
        }

        /// <summary>
        /// Creates a <c>State</c> matrix and goes through it, setting all 
        /// initial board States in each position. 
        /// </summary>
        public Board()
        {
            // Creating a big board to fit the paths in-between
            // playable positions
            state = new State[9, 9];
            turn = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Black pieces on the top half of the board
                    if (i == 0 && j % 4 == 0 ||
                        i == 2 && j % 2 == 0 && j != 0 && j != 8)
                    {
                        state[i, j] = State.B;
                    }
                    // White pieces on the bottom half of the board
                    else if (i == 8 && j % 4 == 0 ||
                             i == 6 && j % 2 == 0 && j != 0 && j != 8)
                    {
                        state[i, j] = State.W;
                    }
                    // Free middle spot 
                    else if (i == 4 && j == 4)
                    {
                        state[i, j] = State.Empty;
                    }
                    // Path Down 
                    else if (i % 2 != 0 && j == 4)
                    {
                        state[i, j] = State.Down;
                    }
                    // Path Side 
                    else if ((i == 0 || i == 8) && j % 4 != 0 ||
                             (i == 2 || i == 6) && (j == 3 || j == 5))
                    {
                        state[i, j] = State.Side;
                    }
                    // Path Diagonal Top Left
                    else if (i == j && i % 2 != 0)
                    {
                        state[i, j] = State.Left;
                    }
                    // Path Diagonal Top Right
                    else if (i == 1 && j == 7 ||
                             i == 3 && j == 5 ||
                             i == 5 && j == 3 ||
                             i == 7 && j == 1)
                    {
                        state[i, j] = State.Right;
                    }
                    // Board Limits
                    else
                    {
                        state[i, j] = State.Blocked;
                    }
                }
            }
        }
        
        /// <summary>
        /// Alternate method to access a <c>State</c> in a <c>Board</c> 
        /// position.
        /// </summary>
        /// <param name="pos">Board coordinates.</param>
        /// <returns>State of corresponding coordinates.</returns>
        public State GetState(Position pos)
        {
            return state[pos.Row, pos.Col];
        }
        
        /// <summary>
        /// Validates the players's first <c>Position</c> input.
        /// Checks if he is trying to grab one of his own pieces.
        /// </summary>
        /// <param name="pos1">Board Coordinates of the position.</param>
        /// <returns>Boolean value, true if the piece picked is valid.</returns>
        public bool ValidatePiece(Position pos1)
        {
            // [Player B] picked a piece.
            if (NextTurn == State.B)
            {
                if (pos1 == null)
                    return false;
                if (state[pos1.Row, pos1.Col] != State.B)
                    return false;
            }

            // [Player W] picked a piece.
            else if (NextTurn == State.W)
            {
                if (pos1 == null)
                    return false;
                if (state[pos1.Row, pos1.Col] != State.W)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the players's second <c>Position</c> input. 
        /// Checks if the move he is trying to perform is valid.
        /// </summary>
        /// <param name="pos1">Board Coordinates of the first position.</param>
        /// <param name="pos2">Board Coordinates of the second position.</param>
        /// <param name="pieceRef">Integer Board reference (1-13) of the first 
        /// position.</param>
        /// <param name="moveToRef">Integer Board reference (1-13) of the second 
        /// position.</param>
        /// <returns>Boolean value, true if the move is valid.</returns>
        public bool ValidateMove(Position pos1, Position pos2, int pieceRef,
                                 int moveToRef)
        {
            // Position and Coordinates of a possible opponent's piece that the
            // player is trying to jump over.
            int pos3Ref;
            Position pos3;

            pos3Ref = JumpedOver(pieceRef, moveToRef);
            pos3 = BoardPosition(pos3Ref);

            // Can only move to positions adjacent to the original.
            if (AreNeighbors(pieceRef, moveToRef) &&
                state[pos2.Row, pos2.Col] == State.Empty)
            {
                // Sets the first position as Empty and the second position as 
                // the player's piece/State.
                state[pos1.Row, pos1.Col] = State.Empty;
                state[pos2.Row, pos2.Col] = NextTurn;
                return true;
            }
            // [Player W] jumping over [Player B] or vice-versa.
            else if ((NextTurn == State.W && pos3 != null &&
                     state[pos3.Row, pos3.Col] == State.B &&
                     state[pos2.Row, pos2.Col] == State.Empty)
                     ||
                     (NextTurn == State.B && pos3 != null &&
                     state[pos3.Row, pos3.Col] == State.W &&
                     state[pos2.Row, pos2.Col] == State.Empty))
            {
                // Eliminates enemy piece jumped over and first position,
                // sets them as Empty and sets the second position as 
                // the player's piece/State.
                state[pos3.Row, pos3.Col] = State.Empty;
                state[pos1.Row, pos1.Col] = State.Empty;
                state[pos2.Row, pos2.Col] = NextTurn;
                return true;
            }
            // Returns false as default if none of the conditions above are met.
            return false;
        }

        /// <summary>
        /// Compares the two given board positions with the board's fixed 
        /// adjacent positions to check if they are also adjacent.
        /// </summary>
        /// <param name="piece">Integer Board reference (1-13) of the first 
        /// position.</param>
        /// <param name="moveTo">Integer Board reference (1-13) of the second 
        /// position.</param>
        /// <returns>Boolean value, true if both board positions are adjacent.
        /// </returns>
        public bool AreNeighbors(int piece, int moveTo)
        {
            // Position 1 on the board. Neighbors are 2 and 4.
            if (piece == 1 && (moveTo == 2 || moveTo == 4))
            {
                return true;
            }
            // Position 2 on the board. Neighbors are 1, 3 and 5.
            else if (piece == 2 && (moveTo == 1 || moveTo == 3 || moveTo == 5))
            {
                return true;
            }
            // Position 3 on the board. Neighbors are 2 and 6.
            else if (piece == 3 && (moveTo == 2 || moveTo == 6))
            {
                return true;
            }
            // Position 4 on the board. Neighbors are 1, 5 and 7.
            else if (piece == 4 && (moveTo == 1 || moveTo == 5 || moveTo == 7))
            {
                return true;
            }
            // Position 5 on the board. Neighbors are 2, 4, 6 and 7.
            else if (piece == 5 && (moveTo == 2 || moveTo == 4 ||
                     moveTo == 6 || moveTo == 7))
            {
                return true;
            }
            // Position 6 on the board. Neighbors are 3, 5 and 7.
            else if (piece == 6 && (moveTo == 3 || moveTo == 5 || moveTo == 7))
            {
                return true;
            }
            // Position 7 on the board. Neighbors are 4, 5, 6, 8, 9 and 10.
            else if (piece == 7 && (moveTo == 4 || moveTo == 5 || moveTo == 6 ||
                     moveTo == 8 || moveTo == 9 || moveTo == 10))
            {
                return true;
            }
            // Position 8 on the board. Neighbors are 7, 9 and 11.
            else if (piece == 8 && (moveTo == 7 || moveTo == 9 || moveTo == 11))
            {
                return true;
            }
            // Position 9 on the board. Neighbors are 7, 8, 10 and 12.
            else if (piece == 9 && (moveTo == 7 || moveTo == 8 ||
                     moveTo == 10 || moveTo == 12))
            {
                return true;
            }
            // Position 10 on the board. Neighbors are 7, 9 and 13.
            else if (piece == 10 && (moveTo == 7 || moveTo == 9 ||
                     moveTo == 13))
            {
                return true;
            }
            // Position 11 on the board. Neighbors are 8 and 12.
            else if (piece == 11 && (moveTo == 8 || moveTo == 12))
            {
                return true;
            }
            // Position 12 on the board. Neighbors are 9, 11 and 13.
            else if (piece == 12 && (moveTo == 9 || moveTo == 11 ||
                     moveTo == 13))
            {
                return true;
            }
            // Position 13 on the board. Neighbors are 10 and 12.
            else if (piece == 13 && (moveTo == 10 || moveTo == 12))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Compares the two given board positions with the board's fixed 
        /// possible jumps positions to check if a jump can be made and which
        /// board position is jumped over.
        /// </summary>
        /// <param name="piece">Integer Board reference (1-13) of the first 
        /// position.</param>
        /// <param name="jumpTo">Integer Board reference (1-13) of the second 
        /// position.</param>
        /// <returns>Integer value, Board reference (1-13) of the position 
        /// jumped over.</returns>
        public int JumpedOver(int piece, int jumpTo)
        {
            // piece = initial position. jumpTo = final position. 

            // Jumping over position 2.
            if      (piece ==  1 && jumpTo ==  3) return  2;
            else if (piece ==  3 && jumpTo ==  1) return  2;

            // Jumping over position 4.
            else if (piece ==  1 && jumpTo ==  7) return  4;
            else if (piece ==  7 && jumpTo ==  1) return  4;

            // Jumping over position 5.
            else if (piece ==  2 && jumpTo ==  7) return  5;
            else if (piece ==  4 && jumpTo ==  6) return  5;
            else if (piece ==  6 && jumpTo ==  4) return  5;
            else if (piece ==  7 && jumpTo ==  2) return  5;

            // Jumping over position 6.
            else if (piece ==  3 && jumpTo ==  7) return  6;
            else if (piece ==  7 && jumpTo ==  3) return  6;

            // Jumping over position 7.
            else if (piece ==  4 && jumpTo == 10) return  7;
            else if (piece ==  5 && jumpTo ==  9) return  7;
            else if (piece ==  6 && jumpTo ==  8) return  7;
            else if (piece ==  8 && jumpTo ==  6) return  7;
            else if (piece ==  9 && jumpTo ==  5) return  7;
            else if (piece == 10 && jumpTo ==  4) return  7;

            // Jumping over position 8.
            else if (piece ==  7 && jumpTo == 11) return  8;
            else if (piece == 11 && jumpTo ==  7) return  8;

            // Jumping over position 9.
            else if (piece ==  7 && jumpTo == 12) return  9;
            else if (piece ==  8 && jumpTo == 10) return  9;
            else if (piece == 10 && jumpTo ==  8) return  9;
            else if (piece == 12 && jumpTo ==  7) return  9;

            // Jumping over position 10.
            else if (piece ==  7 && jumpTo == 13) return 10;
            else if (piece == 13 && jumpTo ==  7) return 10;

            // Jumping over position 12.
            else if (piece == 11 && jumpTo == 13) return 12;
            else if (piece == 13 && jumpTo == 11) return 12;

            // Not jumping over any piece.
            else return 0;
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
                case 1: return new Position(0, 0);
                case 2: return new Position(0, 4);
                case 3: return new Position(0, 8);
                case 4: return new Position(2, 2);
                case 5: return new Position(2, 4);
                case 6: return new Position(2, 6);
                case 7: return new Position(4, 4);
                case 8: return new Position(6, 2);
                case 9: return new Position(6, 4);
                case 10: return new Position(6, 6);
                case 11: return new Position(8, 0);
                case 12: return new Position(8, 4);
                case 13: return new Position(8, 8);
                default: return null;
            }
        }
    }
}