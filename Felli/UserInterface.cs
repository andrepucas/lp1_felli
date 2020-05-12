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
        // the piece they input 
        public int PlayerPicks(State playerTurn)
        {
            string aux;
            int move;

            Console.Write($"Player {playerTurn}, select the "
            + "position of the piece you want to grab: ");
            aux = Console.ReadLine();
            move = int.Parse(aux);
            return move;
        }

        // Renders the selected message to its origin
        public void Message (string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
        }
        
        public void Intro()
        {
            Console.WriteLine(
            
            "\n\n  Welcome to Felli!\n\n" +

            "Instructions:\n" +
            "  - Players decide which color they want and who goes first.\n" +
            "  - The players take turns moving one piece at a time.\n\n" +

            "Turns:\n" +
            "  - The player must first pick which piece he wants to grab.\n" +
            "  - If its a valid one, he can then choose where to move it.\n\n" +
            
            "Valid moves:\n" +
            "  - In any direction where there is a free adjacent stop - [ ].\n" +
            "  - Jumping over an opponent's adjacent piece and landing\n" + 
            "    on a free stop, eliminating the opponent's piece.\n" +
            "  - Only one piece can be eliminated at a time.\n\n" +

            "Type S to start\n");

            while (true)
            {
                // Input variables
                string str = Console.ReadLine();
                string input = str.ToLower();

                if (input == "s")
                {
                    break;
                }
            }
        }

        public void NewRoundMsg(int turn, State PlayerTurn)
        {
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||               ||              ||");
            Console.WriteLine($"||   PLAYER  {PlayerTurn}   ||    " + 
            $"TURN  {turn}   ||");
            Console.WriteLine("||               ||              ||");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||");
        }
    }
}