namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BlueEnemy : Enemy
    {
        public BlueEnemy(Texture2D texture, int x, int y, Enemies complexity)
            : base(texture, x, y, complexity)
        {
            this.SPRITE_ROWS = 2;
            this.SPRITE_COLS = 3;
            this.START_RUN_FRAME = 2;
            this.STOP_RUN_FRAME = 0;
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Damage()
        {
            throw new System.NotImplementedException();
        }

        public override void Enchant()
        {
        }

        public override void Heal()
        {
        }

        public override void Update(GameTime gameTime)
        {
            this.X -= this.Speed;

            if (this.Speed > 0)
            {
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

            if (this.Speed < 0)
            {
                if (this.CurrentFrame <= START_RUN_FRAME + 3)
                {
                    this.CurrentFrame--;
                    if (this.CurrentFrame < STOP_RUN_FRAME + 3)
                    {
                        this.CurrentFrame = START_RUN_FRAME + 3;
                    }
                }
                else
                {
                    this.CurrentFrame = START_RUN_FRAME + 3;
                }
            }

            if (this.X > 775)
            {
                this.Speed = -this.Speed * 1.05f;
            }

            if (this.X < 0)
            {
                this.Speed = -this.Speed * 1.05f;
            }
        }
    }
}