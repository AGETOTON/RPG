namespace AgetotonRPG
{
    using AgetotonRPG.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Coin : IMoveable
    {
        public const int SPRITE_ROWS = 1;
        public const int SPRITE_COLS = 10;
        public const int START_FRAME = 0;
        public const int STOP_FRAME = 9;

        public Coin(Texture2D texture, float x, float y)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.CurrentFrame = 0;
        }
        
        private Texture2D Texture { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public int CurrentFrame { get; set; }

        private Rectangle SourceRectangle { get; set; }

        private Rectangle DestinationRectangle { get; set; }

        public void Update()
        {
            if (this.CurrentFrame >= START_FRAME)
            {
                this.CurrentFrame++;
                if (this.CurrentFrame > STOP_FRAME)
                {
                    this.CurrentFrame = START_FRAME;
                }
            }
            else
            {
                this.CurrentFrame = START_FRAME;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / SPRITE_COLS;
            int height = this.Texture.Height / SPRITE_ROWS;
            int row = this.CurrentFrame / SPRITE_COLS;
            int column = this.CurrentFrame % SPRITE_COLS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}