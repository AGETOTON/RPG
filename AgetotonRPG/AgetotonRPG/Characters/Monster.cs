namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Monster : Enemy
    {
        public Monster(Texture2D texture, int x, int y, Enemies complexity)
            : base(texture, x, y, complexity)
        {
            this.SPRITE_ROWS = 8;
            this.SPRITE_COLS = 10;
            this.START_RUN_FRAME = 29;
            this.STOP_RUN_FRAME = 20;
        }

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