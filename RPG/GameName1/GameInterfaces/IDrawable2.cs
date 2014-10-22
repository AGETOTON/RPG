using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AgetotonRPG.GameInterfaces
{
    public interface IDrawable2
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);

        int CurrentFrame { get; set; }
    }
}
