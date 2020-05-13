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

            Console.Write($"||  [Player {playerTurn}], select the "
            + "position of the piece you want to grab (1-13): ");
            aux = Console.ReadLine();
            move = int.Parse(aux);
            return move;
        }

        public int PlayerMoves(int pos, State playerTurn)
        {
            string aux;
            int move;

            Console.Write($"\n||  [Player {playerTurn}], select where you want "
            + $"to move [{playerTurn}-{pos}] on the board (1-13): ");
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
            Console.WriteLine("\n\n");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||          Felli! - by Iniciados           ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine();
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  Instructions:                           ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  - Players decide which color they want  ||");
            Console.WriteLine("||    and who goes first.                   ||");
            Console.WriteLine("||  - Players take turns moving one piece   ||");
            Console.WriteLine("||    at a time.                            ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  Turns:                                  ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  - The player must first pick which      ||");
            Console.WriteLine("||    piece he wants to grab.               ||");
            Console.WriteLine("||  - If its a valid one, he can then       ||");
            Console.WriteLine("||    choose where to move it.              ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  Valid moves:                            ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||  - In any direction where there is a     ||");
            Console.WriteLine("||    free adjacent stop.                   ||");
            Console.WriteLine("||  - Jumping over an opponent's adjacent   ||");
            Console.WriteLine("||    piece and landing on a free spot,     ||");
            Console.WriteLine("||    eliminating the opponent's piece.     ||");
            Console.WriteLine("||  - Only one piece can be eliminated at   ||");
            Console.WriteLine("||    a time                                ||");
            Console.WriteLine("||                                          ||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||");
            Console.Write("\n||  Type S to start: ");

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
            Console.WriteLine("||              |||              ||");
            Console.WriteLine($"||   PLAYER  {PlayerTurn}  |||    " + 
            $"TURN  {turn}   ||");
            Console.WriteLine("||              |||              ||");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||");
        }
        public int GetTurn()
        {

            while (true)
            {
                Console.Write("\n\n");
                Console.Write("||  Player 1, pick a color to play as (B/W): ");
                string aux1 = Console.ReadLine();
                string player1 = aux1.ToUpper();
                
                Console.Write("\n||  Who is going first? (P1/P2): ");
                string aux2 = Console.ReadLine();
                string answer = aux2.ToUpper();

                if (player1 == "B" && answer == "P2" ||
                    player1 == "W" && answer == "P1")
                {
                    Console.Write("\n\n");
                    Console.Write($"||  Player 1 is now [Player {player1}] ");

                    if (answer == "P1")
                    {
                        Console.WriteLine("and is going to play first.  ||");
                    }
                    else if (answer == "P2")
                    {
                        Console.WriteLine("and is going to play second.  ||");
                    }
                    return 0;
                }               

                else if (player1 == "B" && answer == "P1" ||
                         player1 == "W" && answer == "P2")
                {
                    Console.Write("\n\n");
                    Console.Write($"||  Player 1 is now [Player {player1}] ");
                    
                    if (answer == "P1")
                    {
                        Console.WriteLine("and is going to play first.  ||");
                    }
                    else if (answer == "P2")
                    {
                        Console.WriteLine("and is going to play second.  ||");
                    }
                    return 1;
                }

                else 
                {
                    Console.WriteLine("\n||  At least one of those inputs is " +
                    "not valid. Try again");
                }
            }
        }
    }
}