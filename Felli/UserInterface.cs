using System;

namespace Felli
{
    public class UserInterface
    {
        public void ShowBoard(Board b)
        {
           Console.WriteLine();

           for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (b.GetState(new Position(i, j)))
                    {
                        case State.W:
                            Console.Write(" W ");
                            break;
                        case State.B:
                            Console.Write(" B ");
                            break;
                        case State.Empty:
                            Console.Write(" . ");
                            break;
                        case State.Blocked:
                            Console.Write("   ");
                            break;
                    }
                    
                }
                Console.WriteLine("\n");
                
            }
            Console.WriteLine();
        }
    }
}