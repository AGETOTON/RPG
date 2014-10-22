namespace AgetotonRPG.Characters
{
    using System.Threading;
    using AgetotonRPG.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Character : ICharacter, IMoveable
    {
        protected int SPRITE_ROWS;
        protected int SPRITE_COLS;
        protected int START_RUN_FRAME;
        protected int STOP_RUN_FRAME;
        protected Character(Texture2D texture, float x, float y)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.CurrentFrame = 0;
            this.IsAlive = true;
        }

        public int Lives { get; set; }

        public int Health { get; set; }

        public int Power { get; set; }

        public int Magic { get; set; }

        public bool IsAlive { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public int CurrentFrame { get; set; }

        public Texture2D Texture { get; set; }

        protected Rectangle SourceRectangle { get; set; }

        protected Rectangle DestinationRectangle { get; set; }

        private bool isJumpAvailable = true;

        public abstract void Attack();

        public abstract void Enchant();

        public abstract void Heal();

        public abstract void Damage();


        public abstract void Update(GameTime gameTime);

        protected void AllowJump()
        {
            this.isJumpAvailable = true;
        }

        protected void MakeJump(int value)
        {
            if (this.isJumpAvailable)
            {
                this.Y -= value;
                this.isJumpAvailable = false;
                this.CurrentFrame = 7;
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(200);
                    this.Y += value;
                    this.CurrentFrame = 0;
                });

                thread.Start();
            }
        }

        protected void CheckPosition()
        {
            if (this.X > 775)
            {
                this.X = 0;
            }

            if (this.X < 0)
            {
                this.X = 775;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / this.SPRITE_COLS;
            int height = this.Texture.Height / this.SPRITE_ROWS;
            int row = this.CurrentFrame / this.SPRITE_COLS;
            int column = this.CurrentFrame % this.SPRITE_COLS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            Thread.Sleep(15);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}