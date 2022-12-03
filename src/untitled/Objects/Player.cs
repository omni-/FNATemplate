using FNATemplate.Constants;
using FNATemplate.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNATemplate.Objects
{
    public class Player
    {
        public Vector2 Position;

        public Vector2 Velocity;

        public Vector2 Direction;

        public Texture2D Sprite { get; set; }

        public float MoveSpeed { get; set; }

        private float msNormalized => MoveSpeed * 40;

        public Player() 
        {
            Position = new Vector2();
            Velocity = new Vector2();
            MoveSpeed = 9;
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            var actions = inputManager.GetActiveActions();
            Direction = Vector2.Zero; 
            Velocity = Vector2.Zero;

            if (actions.Contains(Actions.MoveUp))
            {
                Velocity.Y = msNormalized;
                Direction.Y = Directions.Up;
            }
            if (actions.Contains(Actions.MoveDown))
            {
                Velocity.Y = msNormalized;
                Direction.Y = Directions.Down;
            }
            if (actions.Contains(Actions.MoveLeft))
            {
                Velocity.X = msNormalized;
                Direction.X = Directions.Left;
            }
            if (actions.Contains(Actions.MoveRight))
            {
                Velocity.X = msNormalized;
                Direction.X = Directions.Right;
            }

            Position += Direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
