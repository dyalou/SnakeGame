using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class GameWorld
    {
        /// <summary>
        /// Contains the loop that if the snake eats the food, it creates a new random position for it.
        /// and another loop which stats that if the snake hits the wall, the game ends. 
        /// </summary>


        public int Bredd { get; set; }
        public int Höjd { get; set; }
        public int poäng { get; set; }
        /// <summary>
        /// A List containing instances of gameobjects.
        /// </summary>

        public List<GameObject> GameObjects = new List<GameObject>();
        /// <summary>
        /// This Constructor givs the area of the game
        /// </summary>
        ///<param name="Bredd">present the width of the gameworld</param>
        ///<param name="Höjd">present the height of the gameworld</param>
        public GameWorld()
        {
            Bredd = 50;
            Höjd = 20;
            poäng = 0;
            GameObjects = new List<GameObject>();
        }

        /// <summary>
        /// Uppdating the gameworld
        /// </summary>

        public void Update()
        {

            foreach (var obj in GameObjects)// en loop som kontrollerar mat position och orms position
            {
                obj.Update();
            }

            Position playerPosition = new Position(0, 0);
            Position foodPosition = new Position(0, 0);
            Position wallOnePosition = new Position(0, 0);
            Position wallTwoPosition = new Position(0, 0);

            int foodIndex = 0;
            int wallIndex = 0;


            for (int i = 0; i < GameObjects.Count; i++)
            {
                if (GameObjects[i] is Player)
                {
                    playerPosition = GameObjects[i].position;
                }
                else if (GameObjects[i] is Food)
                {
                    foodPosition = GameObjects[i].position;
                    foodIndex = i;
                }
                else if (GameObjects[i] is Wall)
                {
                    Wall firstWall = (Wall)GameObjects[i];
                    Wall secondWall = (Wall)GameObjects[i];

                    if (firstWall.WallNumber == 1)
                    {
                        wallOnePosition = GameObjects[i].position;
                    }

                    else if (secondWall.WallNumber == 2)
                    {
                        wallTwoPosition = GameObjects[i].position;
                    }

                    wallIndex = i;
                }

            }



            if (playerPosition.X == foodPosition.X && playerPosition.Y == foodPosition.Y) // if the snake eats the food, increase the score and change food position
            {
                poäng++;
                GameObjects.RemoveAt(foodIndex);
                GameObjects.Add(CreatFood());
            }

            if ((playerPosition.X == wallOnePosition.X && playerPosition.Y == wallOnePosition.Y) || (playerPosition.X == wallTwoPosition.X && playerPosition.Y == wallTwoPosition.Y)) // if the snake hits the wall, its game over
            {
                throw new SystemException("Wall crash!");
                Console.WriteLine("Opps you died,  Game over!! :( ");
            }

        }


        /// <summary>
        ///Creates a food-item on a random position within the game(x & y need to be set within
        /// a tighter constrain due to the player always being 5 squares away from the edges. 
        /// </summary>
        /// <returns>A food item.</returns>

        public Food CreatFood()
        {
            Random r = new Random();
            int x = r.Next(5, 42);
            int y = r.Next(5, 18);
            Food feed = new Food(new Position(x, y));
            return feed;
        }
    }
}
