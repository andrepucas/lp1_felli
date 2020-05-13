namespace Felli
{
    public class Board
    {
        private State[,] state;
        public int turn;

        public State NextTurn
        {
            get
            {
                if (turn % 2 == 0) return State.W;
                else return State.B;
            }
        }

        public bool Over
        {
            get
            {
                // While != this will return true and the game continues
                return Winner != State.Empty;
            }
        }

        public State Winner
        {
            get
            {
                if (HasWon(State.W)) return State.W;
                if (HasWon(State.B)) return State.B;
                return State.Empty;
            }
        }

        private bool HasWon(State player)
        {
            int countEnemy = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (player == State.W && state[i, j] == State.B)
                    {
                        countEnemy++;
                    }

                    else if (player == State.B && state[i, j] == State.W)
                    {
                        countEnemy++;
                    }
                             
                }      
            }  
            if (countEnemy == 0) return true;
            return false;
        }

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
                    else
                    {
                        state[i, j] = State.Blocked;
                    }
                }
            }
        }

        public State GetState(Position pos)
        {
            return state[pos.Row, pos.Col];
        }

        public bool ValidatePiece(Position pos1)
        {
            if (NextTurn == State.B)
            {
                if (pos1 == null)
                    return false;
                if (state[pos1.Row, pos1.Col] != State.B)
                    return false;
            }
            else if (NextTurn == State.W)
            {
                if (pos1 == null)
                    return false;
                if (state[pos1.Row, pos1.Col] != State.W)
                    return false;
            }
            return true;
        }

        public bool ValidateMove(Position pos1, Position pos2, int pieceRef,
                                 int moveToRef)
        {
            int pos3Ref;
            Position pos3;

            pos3Ref = JumpedOver(pieceRef, moveToRef);
            pos3 = BoardPosition(pos3Ref);

            // Can only move to positions adjacent to the original
            if (AreNeighbors(pieceRef, moveToRef) &&
                state[pos2.Row, pos2.Col] == State.Empty)
            {
                state[pos1.Row, pos1.Col] = State.Empty;
                state[pos2.Row, pos2.Col] = NextTurn;
                return true;
            }
            // [Player X] jumping over [Player X] and vice-versa.
            else if ((NextTurn == State.W && pos3 != null &&
                     state[pos3.Row, pos3.Col] == State.B &&
                     state[pos2.Row, pos2.Col] == State.Empty)
                     ||
                     (NextTurn == State.B && pos3 != null &&
                     state[pos3.Row, pos3.Col] == State.W &&
                     state[pos2.Row, pos2.Col] == State.Empty))
            {
                // Eliminates enemy piece jumped over.
                state[pos3.Row, pos3.Col] = State.Empty;
                state[pos1.Row, pos1.Col] = State.Empty;
                state[pos2.Row, pos2.Col] = NextTurn;
                return true;
            }
            // Cant move outside of board limits
            else if (pos2 == null)
            {
                return false;
            }
            // Cant move to a position that is not empty
            else if (state[pos2.Row, pos2.Col] != State.Empty)
            {
                return false;
            }
            // Cant stay in the same position
            else if (state[pos2.Row, pos2.Col] == state[pos1.Row, pos1.Col])
            {
                return false;
            }
            return false;
        }

        // Checks if two board positions are close to eachother.
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
            else
            {
                return false;
            }
        }

        public int JumpedOver(int piece, int jumpTo)
        {
            // piece = initial position. jumpTo = final position. 

            // Jumping over 2.
            if (piece == 1 && jumpTo == 3) return 2;
            else if (piece == 3 && jumpTo == 1) return 2;
            // Jumping over 4.
            else if (piece == 1 && jumpTo == 7) return 4;
            else if (piece == 7 && jumpTo == 1) return 4;
            // Jumping over 5.
            else if (piece == 2 && jumpTo == 7) return 5;
            else if (piece == 4 && jumpTo == 6) return 5;
            else if (piece == 6 && jumpTo == 4) return 5;
            else if (piece == 7 && jumpTo == 2) return 5;
            // Jumping over 6.
            else if (piece == 3 && jumpTo == 7) return 6;
            else if (piece == 7 && jumpTo == 3) return 6;
            // Jumping over 7.
            else if (piece == 4 && jumpTo == 10) return 7;
            else if (piece == 5 && jumpTo == 9) return 7;
            else if (piece == 6 && jumpTo == 8) return 7;
            else if (piece == 8 && jumpTo == 6) return 7;
            else if (piece == 9 && jumpTo == 5) return 7;
            else if (piece == 10 && jumpTo == 4) return 7;
            // Jumping over 8.
            else if (piece == 7 && jumpTo == 11) return 8;
            else if (piece == 11 && jumpTo == 7) return 8;
            // Jumping over 9.
            else if (piece == 7 && jumpTo == 12) return 9;
            else if (piece == 8 && jumpTo == 10) return 9;
            else if (piece == 10 && jumpTo == 8) return 9;
            else if (piece == 12 && jumpTo == 7) return 9;
            // Jumping over 10.
            else if (piece == 7 && jumpTo == 13) return 10;
            else if (piece == 13 && jumpTo == 7) return 10;
            // Jumping over 12.
            else if (piece == 11 && jumpTo == 13) return 12;
            else if (piece == 13 && jumpTo == 11) return 12;
            else return 0;
        }

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