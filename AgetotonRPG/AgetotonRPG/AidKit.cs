namespace AgetotonRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AidKit
    {
        public AidKit(Texture2D texture, int x, int y)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
        }

        public Texture2D Texture { get; set; }

        public int X { get; set; }

        public int Y { get; set; }


        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle(this.X, this.Y, 30, 25), Color.White);
        }
    }
}