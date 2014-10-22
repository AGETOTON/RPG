using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AgetotonRPG.GameEnums;
using AgetotonRPG.GameInterfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AgetotonRPG.GameClasses
{
    public abstract class Creature:ICreature,IMovable,IDirection,IDrawable2
    {
        
        private int health;
        private int damage;

        private float x;
        private float y;

        private Direction currentDirection;

        private int currentFrame;
        public float Speed { get; set; }

        public bool CanMoveRight { get; set; }
        public bool CanMoveLeft { get; set; }

        public Texture2D Texture { get; set; }

        protected Rectangle SourceRectangle { get; set; }

        protected Rectangle DestinationRectangle { get; set; }

        public Creature Target { get; set; }

        public Creature
            (Texture2D texture, float x, float y)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.Health = health;
            this.Damage = damage;
            this.CanMoveRight = true;
            this.CanMoveLeft = true;
        }
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }
            set
            {
                this.currentFrame = value;
            }
        }

        public Direction CurrentDirection
        {
            get
            {
                return this.currentDirection;
            }
            set
            {
                this.currentDirection = value;
            }
        }

        public abstract bool IsAlive();

        public abstract void WalkRight();

        public abstract void WalkLeft();

        public virtual void Move()
        {
            throw new NotImplementedException();
        }

        public abstract void Draw(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 location);

    }
}
