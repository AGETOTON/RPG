using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AgetotonRPG.Characters
{
    public abstract class Character : ICharacter, IMoveable
    {
        public Character(int life, int power, int magic, Texture2D texture, int x, int y)
        {
            this.Life = life;
            this.Power = power;
            this.Magic = magic;
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.CurrentFrame = 0;
        }

        public int Life { get; set; }
        public int Power { get; set; }
        public int Magic { get; set; }

        public abstract void Attack();
        public abstract void Enchant();
        public abstract void Heal();
        public abstract void Damage();

        public Texture2D Texture { get; set; }
        private Rectangle sourceRectangle;

        private Rectangle SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }

        private Rectangle destinationRectangle;

        public Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }


        public int X { get; set; }

        public int Y { get; set; }

        public int CurrentFrame { get; set; }

        public virtual void Update(GameTime gameTime)
        {

        }
        

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / 8;
            int height = Texture.Height / 4;
            int row = (int)((float)CurrentFrame / (float)8);
            int column = CurrentFrame % 8;

            this.sourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}