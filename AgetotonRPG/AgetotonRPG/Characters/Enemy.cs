namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Enemy : Character
    {
        // Weak enemy stats
        private static int WEAK_HEALTH = 5;
        private static int WEAK_DAMAGE = 2;
        private static float WEAK_SPEED = 0.5f;

        // Average enemy stats
        private static int AVERAGE_HEALTH = 10;
        private static int AVERAGE_DAMAGE = 5;
        private static float AVERAGE_SPEED = 1;

        // Strong enemy stats
        private static int STRONG_HEALTH = 20;
        private static int STRONG_DAMAGE = 9;
        private static float STRONG_SPEED = 2;

        private const int SPRITE_ROWS = 4;
        private const int SPRITE_COLS = 8;
        public const int START_RUN_FRAME = 31;
        public const int STOP_RUN_FRAME = 24;

        public Enemy(Texture2D texture, int x, int y, Enemies complexity)
            : base(texture, x, y)
        {
            this.CurrentFrame = START_RUN_FRAME;
            if (complexity == Enemies.Weak)
            {
                this.Health = WEAK_HEALTH;
                this.Damager = WEAK_DAMAGE;
                this.Speed = WEAK_SPEED;
            }
            else if (complexity == Enemies.Average)
            {
                this.Health = AVERAGE_HEALTH;
                this.Damager = AVERAGE_DAMAGE;
                this.Speed = AVERAGE_SPEED;
            }
            else
            {
                this.Health = STRONG_HEALTH;
                this.Damager = STRONG_DAMAGE;
                this.Speed = STRONG_SPEED;
            }
        }

        private float Speed { get; set; }

        public int Damager { get; set; }

        public override void Damage()
        {
            throw new System.NotImplementedException();
        }

        public override void Attack()
        {

        }


        public override void Enchant()
        {
            throw new System.NotImplementedException();
        }

        public override void Heal()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            this.X -= this.Speed;

            if (this.CurrentFrame <= START_RUN_FRAME)
            {
                this.CurrentFrame--;
                if (this.CurrentFrame < STOP_RUN_FRAME)
                {
                    this.CurrentFrame = START_RUN_FRAME;
                }
            }
            else
            {
                this.CurrentFrame = START_RUN_FRAME;
            }

        }

        public new void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / SPRITE_COLS;
            int height = this.Texture.Height / SPRITE_ROWS;
            int row = this.CurrentFrame / SPRITE_COLS;
            int column = this.CurrentFrame % SPRITE_COLS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            //Thread.Sleep(50);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}
