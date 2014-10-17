using AgetotonRPG.Characters;

namespace AgetotonRPG.Enemies
{
    public class Enemy : IMoveable
    {
        //Weak enemy stats.
        private static int WEAK_HEALTH = 5;
        private static int WEAK_DAMAGE = 2;
        private static int WEAK_SPEED = 3;

        //Average enemy stats.
        private static int AVERAGE_HEALTH = 10;
        private static int AVERAGE_DAMAGE = 5;
        private static int AVERAGE_SPEED = 5;

        //Strong enemy stats
        private static int STRONG_HEALTH = 20;
        private static int STRONG_DAMAGE = 9;
        private static int STRONG_SPEED = 7;

        //Enemy stats.
        private int health;
        private int damage;
        private int speed;
        private int x;
        private int y;
        public Enemy(int start_X, int start_Y, Enemies complexity)
        {
            if (complexity == Enemies.Weak)
            {
                this.Health = Enemy.WEAK_HEALTH;
                this.Damage = Enemy.WEAK_DAMAGE;
                this.Speed = Enemy.WEAK_SPEED;
            }
            else if (complexity == Enemies.Average)
            {
                this.Health = Enemy.AVERAGE_HEALTH;
                this.Damage = Enemy.AVERAGE_DAMAGE;
                this.Speed = Enemy.AVERAGE_SPEED;
            }
            else
            {
                this.Health = Enemy.STRONG_HEALTH;
                this.Damage = Enemy.STRONG_DAMAGE;
                this.Speed = Enemy.STRONG_SPEED;
            }

            this.X = start_X;
            this.Y = start_Y;

        }
        public int Health
        {
            get
            {
                return this.health;
            }
            private set
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
            private set
            {
                this.damage = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            private set
            {
                this.speed = value;
            }
        }
        public Microsoft.Xna.Framework.Graphics.Texture2D Texture
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int X
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

        public int Y
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

        public int CurrentPlayerFrame
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Vector2 location)
        {
            throw new System.NotImplementedException();
        }
    }
}
