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

            Console.Write($"Player [{playerTurn}], select the "
            + "position of the piece you want to move: ");
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
        
        public void intro()
        {
            

            Console.WriteLine("\n\nWelcome to Felli!\n");

            Console.WriteLine("Instructions:");
            Console.WriteLine("-Both players decide which color they want" + 
            " and who goes first.");
            Console.WriteLine("-The players take turns moving 1 piece " +
            "at a time.\n");

            Console.WriteLine("Valid moves:");
            Console.WriteLine("-In any direction where there is a free " + 
            "adjacent stop.");
            Console.WriteLine("-Jumping over an opponent's adjacent piece" + 
            " and landing on a free stop, eliminating the opponent's piece. " +
            "However only 1 piece can be eliminated at a time."); 
            
        }
        public int getTurn()
        {
            string player1, answer;

            while (true)
            {

                int userTurn;

                Console.WriteLine("Choose which color you want to be?(B/W)");
                player1 = Console.ReadLine();

                Console.WriteLine("Do you want to be first?(Y/N)");
                answer = Console.ReadLine();

                if (player1 == "B" && answer == "N" ||
                    player1 == "W" && answer == "Y")
                {

                    Console.WriteLine($"You chose [{player1}]");
                    if (answer == "Y")
                    {
                        Console.WriteLine("and to be first.");
                    }
                    else if (answer == "N")
                    {
                        Console.WriteLine("and to be second.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }

                    return userTurn = 0;

                }

                else if (player1 == "B" && answer == "Y" ||
                        player1 == "W" && answer == "N")
                {

                    Console.WriteLine($"You chose [{player1}]");
                    if (answer == "Y")
                    {
                        Console.WriteLine("and to be first.");
                    }
                    else if (answer == "N")
                    {
                        Console.WriteLine("and to be second.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                    
                    return userTurn = 1;
                }

            }
        }
    }
}