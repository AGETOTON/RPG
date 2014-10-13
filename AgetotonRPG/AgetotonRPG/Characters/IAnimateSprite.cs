using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    public interface IAnimateSprite
    {
        Texture2D Texture { get; set; }

        int Rows { get; set; }

        int Columns { get; set; }

        int CurrentFrame { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}