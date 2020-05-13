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
                if (Over)
                {
                    return State.Empty;
                }
                else if (turn % 2 == 0)
                {
                    return State.W;
                }
                else
                {
                    return State.B;
                }
            }
        }


        public bool Over
        {
            get
            {
                // Returns the player who won
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

        public bool ValidatePiece(Position pos)
        {
            if (NextTurn == State.B)
            {
                if (pos == null) 
                    return false;
                if (state[pos.Row, pos.Col] != State.B)
                    return false;
            }
            else if (NextTurn == State.W)
            {
                if (pos == null) 
                    return false;
                if (state[pos.Row, pos.Col] != State.W)
                    return false;
            }
            return true;
        }

        public bool ValidateMove(Position pos1, Position pos2)
        {
            if (NextTurn == State.B)
            {
                if (pos2 == null) 
                    return false;
                if (state[pos2.Row, pos2.Col] != State.Empty)
                    return false;
                if (state[pos2.Row, pos2.Col] == state[pos1.Row, pos1.Col])
                    return false;
            }
            else if (NextTurn == State.W)
            {
                //copypaste
            }

            state[pos1.Row, pos1.Col] = State.Empty;
            state[pos2.Row, pos2.Col] = NextTurn;
            turn++;
            return true;
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
    }
} 
