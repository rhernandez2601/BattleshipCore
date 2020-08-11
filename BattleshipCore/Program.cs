using Battleship.BLL.GameLogic;
using Battleship.BLL.Requests;
using Battleship.BLL.Ships;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BattleshipCore.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Press any key to play or Q to quit, then press Enter.");

            var playOrQuit = Console.ReadLine();

            if (playOrQuit.ToUpper() == "Q")
                Environment.Exit(0);

            Console.Clear();

            Console.WriteLine("Let the games begin! Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();

            var newGameManager = new GameManager();

            Console.WriteLine("Enter Name Player One!");
            newGameManager.Player1.Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter Name Player Two!");
            newGameManager.Player2.Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"{newGameManager.Player1.Name} vs {newGameManager.Player2.Name}");

            newGameManager.WhoGoesFirst();

            var newGameSetup = new GameSetup();

            if (newGameManager.Player1.Order == 1)
            {
                Console.WriteLine($"{newGameManager.Player1.Name} is going first.");
                Console.WriteLine($"Press enter to start {newGameManager.Player1.Name}'s board setup");
                Console.ReadLine();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player1.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player1);
                Console.WriteLine($"Press Enter to finish your board setup.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"Press enter to start {newGameManager.Player2.Name}'s board setup");
                Console.ReadLine();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player2.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player2);
                Console.WriteLine($"Press Enter to finish your board setup and start game.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"{newGameManager.Player2.Name} is going first.");
                Console.WriteLine($"Press enter to start {newGameManager.Player2.Name}'s board setup");
                Console.ReadLine();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player2.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player2);
                Console.WriteLine($"Press Enter to finish your board setup.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"Press enter to start {newGameManager.Player1.Name}'s board setup");
                Console.ReadLine();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player1.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player1);
                Console.WriteLine($"Press Enter to finish your board setup and start game.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
