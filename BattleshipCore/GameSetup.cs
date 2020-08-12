using Battleship.BLL.GameLogic;
using Battleship.BLL.Requests;
using Battleship.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipCore.UI
{
    public class GameSetup
    {
        public void RenderBoard(Board board)
        {
            for (int i = 0; i <= 10; i++)
            {
                var rowSB = new StringBuilder();

                if (i > 0)
                {
                    switch (i)
                    {
                        case 1:
                            rowSB.Append("a ");
                            break;
                        case 2:
                            rowSB.Append("b ");
                            break;
                        case 3:
                            rowSB.Append("c ");
                            break;
                        case 4:
                            rowSB.Append("d ");
                            break;
                        case 5:
                            rowSB.Append("e ");
                            break;
                        case 6:
                            rowSB.Append("f ");
                            break;
                        case 7:
                            rowSB.Append("g ");
                            break;
                        case 8:
                            rowSB.Append("h ");
                            break;
                        case 9:
                            rowSB.Append("i ");
                            break;
                        default:
                            rowSB.Append("j ");
                            break;
                    }

                    for (int j = 1; j <= 10; j++)
                    {
                        if (board.Ships[0] != null)
                        {
                            if (board.Ships.Where(s => s != null).Any(s => s.BoardPositions.Where(b => b != null).Any(b => b.XCoordinate == i && b.YCoordinate == j)))
                            {
                                var ship = board.Ships.Where(s => s.BoardPositions.Any(b => b.XCoordinate == i && b.YCoordinate == j)).FirstOrDefault();
                                rowSB.Append(ship.ShipName.Substring(0, 1) + " ");
                            }
                            else
                                rowSB.Append("O ");
                        }
                        else
                            rowSB.Append("O ");
                    }
                }
                else
                    rowSB.Append("0 1 2 3 4 5 6 7 8 9 10");

                Console.WriteLine(rowSB.ToString());
            }
        }
        public void SetupPlayerBoard(Player player)
        {
            foreach (var ship in Enum.GetValues(typeof(ShipType)))
            {
                switch (ship)
                {
                    case ShipType.Destroyer:
                        Console.WriteLine($"{player.Name}, place your Destroyer (occupies 2 spaces). Enter a coordinate (ex. B7).");
                        break;
                    case ShipType.Cruiser:
                        Console.WriteLine($"{player.Name}, place your Cruiser (occupies 3 spaces). Enter a coordinate (ex. B7).");
                        break;
                    case ShipType.Submarine:
                        Console.WriteLine($"{player.Name}, place your Submarine (occupies 3 spaces). Enter a coordinate (ex. B7)."); 
                        break;
                    case ShipType.Battleship:
                        Console.WriteLine($"{player.Name}, place your Battleship (occupies 4 spaces). Enter a coordinate (ex. B7)."); 
                        break;
                    default:
                        Console.WriteLine($"{player.Name}, place your Carrier (occupies 5 spaces). Enter a coordinate (ex. B7).");
                        break;
                }
                string coordinate = Console.ReadLine();
                coordinate = ValidationUtils.ValidateNonEmptyString(coordinate, "Weally?!?!?!?!?! Type a coordinate you weirdo!!!!!");
                coordinate = ValidationUtils.ValidateCoordinate(coordinate, "Weally?!?!?!?!?! Type a coordinate you weirdo!!!!!");

                PlaceShipRequest placeShipRequest = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(coordinate),
                    ShipType = (ShipType)ship
                };

                Console.WriteLine("Which direction will the ship go (u for up, d for down, r for right, l for left?");
                var direction = Console.ReadLine();
                direction = ValidationUtils.ValidateNonEmptyString(direction, "Weally?!?!?!?!?! Type a real direction (u for up, d for down, r for right, l for left)!");
                direction = ValidationUtils.ValidateDirectionOfShip(direction, "Weally?!?!?!?!?! Type a real direction (u for up, d for down, r for right, l for left)!");
                switch (direction.ToLower())
                {
                    case "u":
                        placeShipRequest.Direction = ShipDirection.Up;
                        break;
                    case "d":
                        placeShipRequest.Direction = ShipDirection.Down;
                        break;
                    case "r":
                        placeShipRequest.Direction = ShipDirection.Right;
                        break;
                    default:
                        placeShipRequest.Direction = ShipDirection.Left;
                        break;
                }

                player.Board.PlaceShip(placeShipRequest);

                Console.Clear();
                RenderBoard(player.Board);
            }
        }
    }
}
