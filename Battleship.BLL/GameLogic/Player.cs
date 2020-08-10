using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.BLL.GameLogic
{
    public class Player
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public Board Board { get; set; }

        public Player()
        {
            Board = new Board();
        }
    }

}
