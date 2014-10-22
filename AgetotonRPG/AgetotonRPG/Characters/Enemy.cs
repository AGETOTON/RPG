namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Enemy : Character
    {
        // Weak enemy stats
        protected static int WEAK_HEALTH = 5;
        protected static int WEAK_DAMAGE = 2;
        protected static float WEAK_SPEED = 0.5f;

        // Average enemy stats
        protected static int AVERAGE_HEALTH = 10;
        protected static int AVERAGE_DAMAGE = 5;
        protected static float AVERAGE_SPEED = 1;

        // Strong enemy stats
        protected static int STRONG_HEALTH = 20;
        protected static int STRONG_DAMAGE = 9;
        protected static float STRONG_SPEED = 1.5f;

        protected Enemy(Texture2D texture, int x, int y, Enemies complexity)
            : base(texture, x, y)
        {
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

            if (this is BlueEnemy)
            {
                this.SPRITE_ROWS = 2;
                this.SPRITE_COLS = 3;
                this.START_RUN_FRAME = 2;
                this.STOP_RUN_FRAME = 0;
            }

        }


        protected float Speed { get; set; }

        public int Damager { get; set; }
    }
}