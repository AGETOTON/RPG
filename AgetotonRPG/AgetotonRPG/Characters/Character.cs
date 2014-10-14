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

        public int X { get; set; }
        public int Y { get; set; }
        public int CurrentFrame { get; set; }

        public Texture2D Texture { get; set; }

        private Rectangle SourceRectangle { get; set; }
        public Rectangle DestinationRectangle { get; set; }

        public abstract void Attack();
        public abstract void Enchant();
        public abstract void Heal();
        public abstract void Damage();

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / MainSettings.SPRITE_COLS;
            int height = Texture.Height / MainSettings.SPRITE_ROWS;
            int row = (int)((float)CurrentFrame / (float)MainSettings.SPRITE_COLS);
            int column = CurrentFrame % MainSettings.SPRITE_COLS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            Thread.Sleep(90);

            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
        }
    }
}