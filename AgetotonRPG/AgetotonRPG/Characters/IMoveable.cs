using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    public interface IMoveable
    {
        Texture2D Texture { get; set; }

        int X { get; set; }

        int Y { get; set; }

        int CurrentFrame { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}