using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipCore.UI
{
    public static class ValidationUtils
    {
        public static void ValidateEnter()
        {
            var response = Console.ReadKey().Key.ToString();
            while (response != "Enter")
            {
                Console.Clear();
                Console.WriteLine("Weally?!?!?!?!?! You weren't supposed to type that! Press Enter to continue!");
                response = Console.ReadKey().Key.ToString();
            }
        }
        public static string ValidateNonEmptyString(string response, string errorMessage)
        {
            while (response == "")
            {
                Console.Clear();
                Console.WriteLine(errorMessage);
                response = Console.ReadLine();
            }
            return response;
        }
        public static string ValidateDirectionOfShip(string response, string errorMessage)
        {
            response = response.ToLower();

            while (response != "u" && response != "d" && response != "l" && response != "r")
            {
                Console.Clear();
                Console.WriteLine(errorMessage);
                response = Console.ReadLine().ToLower();
            }
            return response;
        }
        public static string ValidateCoordinate(string response, string errorMessage)
        {
            while (response.Length != 2 && response.Length != 3)
            {
                Console.WriteLine(errorMessage);
                response = Console.ReadLine().ToLower();
            }

            var x = response.Substring(0, 1).ToLower();

            while (x != "a" && x != "b" && x != "c" && x != "d" && x != "e" && x != "f" && x != "g" && x != "h" && x != "i" && x != "j")
            {
                Console.WriteLine(errorMessage);
                response = Console.ReadLine();
                x = response.Substring(0, 1).ToLower();
            }

            var y = response.Substring(1);
            var yInt = 0;

            while (!int.TryParse(y, out yInt) || (yInt < 1 || yInt > 10))
            {
                Console.WriteLine(errorMessage);
                response = Console.ReadLine();
                y = response.Substring(1);
            }
            return response;
        }
    }
}
