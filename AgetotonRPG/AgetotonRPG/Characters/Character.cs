using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AgetotonRPG.Characters
{
    public abstract class Character : ICharacter, IAnimateSprite
    {
        public Character(int life, int power, int magic, Texture2D texture, int rows, int columns)
        {
            this.Life = life;
            this.Power = power;
            this.Magic = magic;
            this.Texture = texture;
            this.Rows = rows;
            this.Columns = columns;
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

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int CurrentFrame { get; set; }

        public void Update()
        {
            this.CurrentFrame++;
            if (CurrentFrame == MainSettings.MAX_CHARACTER_FRAMES)
                CurrentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            //spriteBatch.Begin();
            Thread.Sleep(300);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            //spriteBatch.End();
        }
    }
}