using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Player : GameObject
    {
        /// <summary>
        /// Setting the directions which the player will move (right, left, up, down) , and what keys that are clicked 
        /// to move the snake (W, A, S, D)
        /// </summary>

        public enum Direction
        {
            upp, ner, höger, vänster
        }

        public Direction playerD;

        public Player() //to create an object  without parameters 
        {

        }
        public Player(Position newPosition)
        {
            position = newPosition;
            Apperance = '$';
            playerD = Direction.upp;

        }
        public void SetDirection(Direction direction)
        {
            playerD = direction;
        }
        /// <summary>
        /// The snake keeps moving even if it hits the edges.
        /// </summary>
        public void ControlPosition()
        {
            if (position.X > 49)
            {
                position.X = 0;
            }
            else if (position.Y > 19)
            {
                position.Y = 0;
            }
            else if (position.X < 0)
            {
                position.X = 49;
            }
            else if (position.Y < 0)
            {
                position.Y = 19;
            }
        }
        /// <summary>
        /// updatining snake move och cotronlering snake position
        /// </summary>
        public override void Update()
        {
            if (playerD == Direction.upp)
            {
                position.Y -= 1;
                ControlPosition();
            }
            else if (playerD == Direction.ner)
            {
                position.Y += 1;
                ControlPosition();
            }
            else if (playerD == Direction.vänster)
            {
                position.X -= 1;
                ControlPosition();
            }
            else if (playerD == Direction.höger)
            {
                position.X += 1;
                ControlPosition();
            }
        }
    }
}
