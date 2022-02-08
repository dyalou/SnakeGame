using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class ConsoleRenderer
    {
        /// <summary>
        /// This class creates the window of our program.
        /// How big is the window, and the object inside this window.
        /// </summary>

        private GameWorld world;

        /// <summary>
        /// set the size of the program's window
        /// </summary>
        /// <param name="gameWorld"></param>
        public ConsoleRenderer(GameWorld gameWorld)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 20);
            world = gameWorld;
        }

        /// <summary>
        /// To render our objects (snake, food, wall) in our program
        /// </summary>
        public void Render()
        {
            foreach (var gameObject in world.GameObjects)
            {
                Console.SetCursorPosition(gameObject.position.X, gameObject.position.Y);
                Console.Write(gameObject.Apperance);
            }



            for (int i = 0; i <= 1; i++) // to add the score of the program
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Score: " + world.poäng);
            }

        }
        /// <summary>
        /// This removes the trail of the snake, and the window stops blinking
        /// </summary>

        public void RenderBlank()
        {

            foreach (var gameObject in world.GameObjects)
            {
                Console.SetCursorPosition(gameObject.position.X, gameObject.position.Y);
                Console.Write(" ");
            }
        }
    }
}
