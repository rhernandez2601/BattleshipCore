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

        public void WhoGoesFirst()
        {
            Random random = new Random();
            var order = random.Next(1, 3);

            if (order == 1)
            {
                Player1.Order = 1;
                Player2.Order = 2;
            }
            else
            {
                Player2.Order = 1;
                Player1.Order = 2;
            }
        }
    }
}
