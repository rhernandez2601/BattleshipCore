using System;

namespace Battleship.BLL.Requests
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public Coordinate(string coord)
        {
            var firstChar = coord.Substring(0, 1);
            var secondChar = coord.Substring(1);

            switch (firstChar.ToLower())
            {
                case "a":
                    XCoordinate = 1;
                    break;
                case "b":
                    XCoordinate = 2;
                    break;
                case "c":
                    XCoordinate = 3;
                    break;
                case "d":
                    XCoordinate = 4;
                    break;
                case "e":
                    XCoordinate = 5;
                    break;
                case "f":
                    XCoordinate = 6;
                    break;
                case "g":
                    XCoordinate = 7;
                    break;
                case "h":
                    XCoordinate = 8;
                    break;
                case "i":
                    XCoordinate = 9;
                    break;
                default:
                    XCoordinate = 10;
                    break;
            }

            YCoordinate = int.Parse(secondChar);
        }

        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == this.XCoordinate &&
                   otherCoordinate.YCoordinate == this.YCoordinate;
        }
		
		public override int GetHashCode() 
        { 
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00"; 
            return (Convert.ToInt32(uniqueHash)); 
        } 

    }
}
