using System;

namespace Felli
{
    public class UserInterface
    {
        public void ShowBoard(Board b)
        {
            Console.WriteLine();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
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
                Console.WriteLine("\n");
            }

        }

        public void intro()
        {

            Console.WriteLine("\n\nWelcome to Felli!\n");

            Console.WriteLine("Instructions:");
            Console.WriteLine("-Both player decide which color they want" + 
            " and who goes first.");
            Console.WriteLine("-Then the players take turn moving 1 piece " +
            "at a time\n");

            Console.WriteLine("Valid moves:");
            Console.WriteLine("-In any direction where there is a free " + 
            "adjacent stop.");
            Console.Write("-Jumping over an opponent's adjacent piece" + 
            " and landing on a free stop, eleminating the opponent's piece.");
            Console.WriteLine(
            "However only 1 piece can be eliminated at a time");
        
        }


        // public int getTurn()
        // {
        //     string player1, answer;

        //     int userTurn;

        //     while (true)
        //     {

        //         Console.WriteLine("Choose which color you want to be?(B/W)");
        //         player1 = Console.ReadLine();

        //         Console.WriteLine("Do you want to be first?(Y/N)");
        //         answer = Console.ReadLine();

        //         if (player1 == "B" && answer == "N" ||
        //             player1 == "W" && answer == "Y")
        //         {

        //             Console.WriteLine($"You chose [{player1}]");
        //             if (answer == "Y")
        //             {
        //                 Console.WriteLine("and to be first.");
        //             }
        //             else if (answer == "N")
        //             {
        //                 Console.WriteLine("and to be second.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid Input!");
        //             }

        //             return userTurn = 0;

        //         }

        //         else if (player1 == "B" && answer == "Y" ||
        //                 player1 == "W" && answer == "N")
        //         {

        //             Console.WriteLine($"You chose [{player1}]");
        //             if (answer == "Y")
        //             {
        //                 Console.WriteLine("and to be first.");
        //             }
        //             else if (answer == "N")
        //             {
        //                 Console.WriteLine("and to be second.");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Invalid Input!");
        //             }
                    
        //             return userTurn = 1;
        //         }
        //         else
        //             {
        //                 Console.WriteLine("Invalid Input!");
        //             }

        //     }
        //}
    }
}