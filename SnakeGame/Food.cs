using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Food : GameObject
    {
        /// <summary>
        /// This class creates the food that the snake eats.
        /// It also creates the apperance of the food, and the positon object.
        /// </summary>
        /// <param name="newPosition">the food position object</param>

        public Food(Position newPosition)
        {
            position = newPosition;
            Apperance = 'o';
        }

        public override void Update()
        {

        }
    }
}
