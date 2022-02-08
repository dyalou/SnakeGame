using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal abstract class GameObject
    {  /// <summary>
       /// This class creates the objects like position, the charecter or the apperance of the snake, food, and wall.
       /// </summary>

        public Position position;
        public char Apperance;
        public Wall wall;

        /// <summary>
        /// Abstract method for object
        /// </summary>
        public abstract void Update();

    }
}
