namespace Felli
{
    public class Board
    {
        private State[,] state;
        private int turn;

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
                if (hasWon(State.W)) return State.W;
                if (hasWon(State.B)) return State.B;
                return State.Empty;
            }
        }

        public Board()
        {
            state = new State[5, 5];
            turn = 0;
            
            // Setting playable area - All even/even and odd/odd positions 
            //     have Black pieces in the first 2 lines and White pieces 
            //     in the last 2 lines. All other positions are blocked with 
            //     the exception of the middle one (2,2).
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i < 2 && i % 2 == 0 && j % 2 == 0 ||
                        i < 2 && i % 2 != 0 && j % 2 != 0)
                    {
                        state[i, j] = State.B; 
                    }
                    else if (i > 2 && i % 2 == 0 && j % 2 == 0 ||
                             i > 2 && i % 2 != 0 && j % 2 != 0)
                    {
                        state[i, j] = State.W; 
                    }
                    else if (i == 2 && j == 2)
                    {
                        state[i, j] = State.Empty; 
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