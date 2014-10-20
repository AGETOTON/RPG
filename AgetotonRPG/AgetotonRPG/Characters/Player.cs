namespace AgetotonRPG.Characters
{
    using System.Threading;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player : Character
    {
        public const int MAX_LIVES = 5;

        public const int MAX_HEALTH = 50;

        public const int MAX_POWER = 100;

        public const int MAX_MAGIC = 10;

        public const int START_RUN_FRAME = 24;

        public const int STOP_RUN_FRAME = 31;

        public const float SPEED = 2;

        public const int JUMP_HEIGTH = 50;

        public const int SPRITE_ROWS = 8;

        public const int SPRITE_COLS = 8;

        public Player(Texture2D texture, float x, float y)
            : base(texture, x, y)
        {
            this.Lives = MAX_LIVES;
            this.Health = MAX_HEALTH;
            this.Power = MAX_POWER;
            this.Magic = MAX_MAGIC;
        }

        public int Score { get; private set; }

        public override void Attack()
        {
            this.Power -= 5;
        }

        public override void Enchant()
        {
            this.Magic -= 10;
        }

        public override void Heal()
        {
            this.Health += 10;
            this.Power += 10;
            this.Magic += 10;
        }

        public override void Damage()
        {
            this.Power -= 10;
        }

        public void IncrementScore()
        {
            this.Score += 10;
        }

        public override void Update(GameTime gameTime)
        {
            this.UpdateInput();
            this.CheckPosition();
            // other updates...
        }

        private void UpdateInput()
        {
            KeyboardState currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(Keys.Right))
            {
                this.X += SPEED;
                if (this.CurrentFrame >= START_RUN_FRAME)
                {
                    this.CurrentFrame++;
                    if (this.CurrentFrame > STOP_RUN_FRAME)
                    {
                        this.CurrentFrame = START_RUN_FRAME;
                    }
                }
                else
                {
                    this.CurrentFrame = START_RUN_FRAME;
                }
            }                        

            if (currentState.IsKeyDown(Keys.Left))
            {
                this.X -= SPEED;

                if (this.CurrentFrame >= START_RUN_FRAME+32)
                {
                    this.CurrentFrame++;
                    if (this.CurrentFrame > STOP_RUN_FRAME+32)
                    {
                        this.CurrentFrame = START_RUN_FRAME+32;
                    }
                }
                else
                {
                    this.CurrentFrame = START_RUN_FRAME+32;
                }
            }

            if (currentState.IsKeyDown(Keys.Space))
            {
                this.MakeJump(JUMP_HEIGTH);
            }
            else if (currentState.IsKeyUp(Keys.Space))
            {
                this.AllowJump();
            }

            if (currentState.IsKeyDown(Keys.X))
            {
                this.CurrentFrame = 1;
            }

            if (currentState.IsKeyUp(Keys.Right) &&
                currentState.IsKeyUp(Keys.Space) &&
                currentState.IsKeyUp(Keys.Left) &&
                currentState.IsKeyUp(Keys.X))
            {
                this.CurrentFrame = 0;
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

            Thread.Sleep(90);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}