using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Wall : GameObject
    {

        /// <summary>
        /// This class creates the wall or obstacles that the snake might hit and end the game.
        /// It also creates the apperance of the wall, and the positon object.
        /// </summary>

        public int WallNumber { get; set; }

        public Wall(Position wallPosition)
        {
            position = wallPosition;
            Apperance = '|';
        }

        public override void Update()
        {

        }
    }
}
