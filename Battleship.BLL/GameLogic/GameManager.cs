using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.BLL.GameLogic
{
    public class GameManager
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public GameManager()
        {
            Player1 = new Player();
            Player2 = new Player();
        }
    }
}
