using System;

namespace Felli
{
    public class UserInterface
    {
        // Draws board, the outside box and paths are fixed while the
        // playable spots can change every time the board is rendered.
        public void ShowBoard(Board b)
        {
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                               ||");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0) 
                    {
                        Console.Write("||  ");
                    }

                    switch (b.GetState(new Position(i, j)))
                    {
                        // Playable Spots:
                        case State.B:
                            Console.Write("[B]");
                            break;
                        case State.W:
                            Console.Write("[W]");
                            break;
                        case State.Empty:
                            Console.Write("[ ]");
                            break;

                        // Board Limits and Paths:
                        case State.Down:
                            Console.Write(" | ");
                            break;
                        case State.Side:
                            Console.Write(" - ");
                            break;
                        case State.Left:
                            Console.Write(" \\ ");
                            break;
                        case State.Right:
                            Console.Write(" / ");
                            break;
                        case State.Blocked:
                            Console.Write("   ");
                            break;
                    }
                }
                Console.WriteLine("  ||");
                Console.WriteLine("||                               ||");
            
                if (i == 8)
                {
                    Console.WriteLine("|||||||||||||||||||||||||||||||||||\n");
                }
            }
        }

        // Asks the corresponding player and saves the position of 
        // the button they input 
        public int PlayerPicks(State playerTurn)
        {
            string aux;
            int move;

            Console.Write($"Player [{playerTurn}], select the "
            + "position of the button you want to move: ");
            aux = Console.ReadLine();
            move = int.Parse(aux);
            return move;
        }

        // Renders the selected message to its origin
        public void Message (string msg)
        {
            Console.WriteLine(msg);
        }
    }
}