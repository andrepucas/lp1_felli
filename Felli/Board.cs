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


        // public void Turn(int userTurn)
        // {
        //     turn = ui.getTurn.userTurn;
        // }



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
                if (hasWon(State.W)) return State.W;
                if (hasWon(State.B)) return State.B;
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

        private bool hasWon(State player)
        {
            // DEBUG: Serve so para testar e dizer ao ciclo para continuar.
            return false;
        }

    


    }
}