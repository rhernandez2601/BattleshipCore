using Battleship.BLL.GameLogic;
using System;

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

            Console.WriteLine("Let the games begin! Press Enter to continue.");

            var newGameManager = new GameManager();

            Console.WriteLine("Enter Name Player One!");
            newGameManager.Player1.Name = Console.ReadLine();

            Console.WriteLine("Enter Name Player Two!");
            newGameManager.Player2.Name = Console.ReadLine();

            //Console.WriteLine("{0} vs {1}", newGameManager.Player1.Name, newGameManager.Player2.Name);
            Console.WriteLine($"{newGameManager.Player1.Name} vs {newGameManager.Player2.Name}");
        }
    }
}
