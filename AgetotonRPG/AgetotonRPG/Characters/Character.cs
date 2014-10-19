namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Threading;

    public abstract class Character : ICharacter, IMoveable
    {
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


        public virtual void Update(GameTime gameTime)
        {
            //this.Update(gameTime);
        }

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
                this.X =775;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            this.Draw(spriteBatch, location);
        }
    }
}