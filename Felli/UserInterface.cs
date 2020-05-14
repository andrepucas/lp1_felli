using System;

namespace Felli
{
    /// <summary>
    /// <c>UserInterface</c> Class.
    /// Contains all user interaction methods and prints.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Draws board.
        /// The outside box is fixed while the board paths, limits and
        /// playable spots will be updated every time the board is rendered 
        /// according to the <c>State</c>.
        /// </summary>
        /// <param name="b">Board that the program is using.</param>
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

                    // Goes through each board position.
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

                // Last line of the box.
                if (i == 8)
                {
                    Console.WriteLine("|||||||||||||||||||||||||||||||||||\n");
                }
            }

        }

        /// <summary>
        /// Asks player which piece he wants to "grab".
        /// </summary>
        /// <param name="playerTurn">State of current player.</param>
        /// <returns>Integer value, first board position.</returns>
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

        /// <summary>
        /// Asks player where he wants to move his piece.
        /// </summary>
        /// <param name="pos">Integer Board reference of the first piece (1-13).
        /// </param>
        /// <param name="playerTurn">State of current player.</param>
        /// <returns>Integer value, second board position.</returns>
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

        /// <summary>
        /// Renders a console message.
        /// </summary>
        /// <param name="msg">String of what to render.</param>
        public void Message(string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Introduction screen with program guidelines.
        /// Waits for the player to input "S" to proceed.
        /// </summary>
        public void Intro()
        {
            // Introduction
            Console.WriteLine("\n");
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

            // Wait until user types "S"
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

        /// <summary>
        /// Current round information like who's playing and turn number.
        /// </summary>
        /// <param name="turn">Integer turn value.</param>
        /// <param name="PlayerTurn">State of current player.</param>
        public void NewRoundMsg(int turn, State PlayerTurn)
        {
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||              |||              ||");
            
            // Fixes box misalignment when the turns go over one digits
            if (turn < 10) 
            {
                Console.WriteLine($"||   PLAYER  {PlayerTurn}  |||    " +
                                  $"TURN  {turn}   ||");
            }
            else
            {
                Console.WriteLine($"||   PLAYER  {PlayerTurn}  |||    " +
                                  $"TURN  {turn}  ||");
            }
            Console.WriteLine("||              |||              ||");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||");
        }
        
        /// <summary>
        /// Asks players which color they want to play as and who is going 
        /// first. 
        /// </summary>
        /// <returns>Integer value, represents initial turn.</returns>
        public int GetTurn()
        {
            while (true)
            {
                // Ask [Player 1] which color they want.
                Console.Write("\n\n");
                Console.Write("||  [Player 1], pick a color to " + 
                "play as (B/W): ");
                string aux1 = Console.ReadLine();
                string player1 = aux1.ToUpper();

                // Ask both Players who is going first.
                Console.Write("\n||  [Player 1/2], " + 
                "which of you is going first? (P1/P2): ");
                string aux2 = Console.ReadLine();
                string answer = aux2.ToUpper();

                // Setting first turn.
                if (player1 == "B" && answer == "P2" ||
                    player1 == "W" && answer == "P1")
                {
                    Console.Write("\n\n");
                    Console.Write($"||  [Player 1] is now [Player {player1}] ");

                    if (answer == "P1")
                    {
                        Console.WriteLine("and is going to play first.");
                    }
                    else if (answer == "P2")
                    {
                        Console.WriteLine("and is going to play second.");
                    }
                    return 0;
                }

                else if (player1 == "B" && answer == "P1" ||
                         player1 == "W" && answer == "P2")
                {
                    Console.Write("\n\n");
                    Console.Write($"||  [Player 1] is now [Player {player1}] ");

                    if (answer == "P1")
                    {
                        Console.WriteLine("and is going to play first.");
                    }
                    else if (answer == "P2")
                    {
                        Console.WriteLine("and is going to play second.");
                    }
                    return 1;
                }

                // Error message.
                else
                {
                    Console.WriteLine("\n||  At least one of those inputs is " +
                    "not valid. Try again");
                }
            }
        }
        
        /// <summary>
        /// Renders winner's box.
        /// </summary>
        /// <param name="Winner">State of winning player.</param>
        /// <param name="turns">Integer turn value.</param>
        public void WinBox(State Winner, int turns)
        {
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||                               ||");
            Console.WriteLine($"||         PLAYER {Winner} WINS         ||");
            Console.WriteLine("||                               ||");
            Console.WriteLine($"||       ONLY TOOK {turns} TURNS       ||");
            Console.WriteLine("||                               ||");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||");
        }
    }
}