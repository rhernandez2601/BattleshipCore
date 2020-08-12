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
            Console.WriteLine("Press Enter to play or Q to quit.");

            var response = Console.ReadKey().Key.ToString();

            while (response != "Enter" && response.ToUpper() != "Q")
            {
                Console.Clear();
                Console.WriteLine("Weally?!?!?!?!?! You weren't supposed to type that! Press Enter to play or Q to Quit!");
                response = Console.ReadKey().Key.ToString();
            }

            if (response.ToUpper() == "Q")
                Environment.Exit(0);

            Console.Clear();

            Console.WriteLine("Let the games begin! Press Enter to continue.");
            ValidationUtils.ValidateEnter();

            Console.Clear();

            var newGameManager = new GameManager();

            Console.WriteLine("Enter Name Player One!");
            response = Console.ReadLine();
            response = ValidationUtils.ValidateNonEmptyString(response, "Weally?!?!?!?!?! Type a real name you weirdo!!!!!");
            newGameManager.Player1.Name = response;
            Console.Clear();

            Console.WriteLine("Enter Name Player Two!");
            response = Console.ReadLine();
            response = ValidationUtils.ValidateNonEmptyString(response, "Weally?!?!?!?!?! Type a real name you weirdo!!!!!");
            newGameManager.Player2.Name = response;
            Console.Clear();

            Console.WriteLine($"{newGameManager.Player1.Name} vs {newGameManager.Player2.Name}");

            newGameManager.WhoGoesFirst();

            var newGameSetup = new GameSetup();

            if (newGameManager.Player1.Order == 1)
            {
                Console.WriteLine($"{newGameManager.Player1.Name} is going first.");
                Console.WriteLine($"Press Enter to start {newGameManager.Player1.Name}'s board setup");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player1.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player1);
                Console.WriteLine($"Press Enter to finish your board setup.");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                Console.WriteLine($"Press Enter to start {newGameManager.Player2.Name}'s board setup");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player2.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player2);
                Console.WriteLine($"Press Enter to finish your board setup and start game.");
                ValidationUtils.ValidateEnter();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"{newGameManager.Player2.Name} is going first.");
                Console.WriteLine($"Press enter to start {newGameManager.Player2.Name}'s board setup");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player2.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player2);
                Console.WriteLine($"Press Enter to finish your board setup.");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                Console.WriteLine($"Press enter to start {newGameManager.Player1.Name}'s board setup");
                ValidationUtils.ValidateEnter();
                Console.Clear();

                newGameSetup.RenderBoard(newGameManager.Player1.Board);
                newGameSetup.SetupPlayerBoard(newGameManager.Player1);
                Console.WriteLine($"Press Enter to finish your board setup and start game.");
                ValidationUtils.ValidateEnter();
                Console.Clear();
            }
        }
    }
}
