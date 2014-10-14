using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AgetotonRPG.Characters;
using Microsoft.Xna.Framework.Input;

namespace AgetotonRPG
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }

        private Texture2D background;

        private SpriteFont font;

        private PaladinHero pesho;

        public ScreenManager()
        {
            Dimensions = new Vector2(MainSettings.MAIN_WINDOW_X, MainSettings.MAIN_WINDOW_Y);
        }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }

                return instance;
            }
        }

        public void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("cave");
            font = Content.Load<SpriteFont>("fonts/BlackOpsOne");

            pesho = new PaladinHero(12, 3, 5, Content.Load<Texture2D>("players/hero"), 300, 450);
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            pesho.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.DrawString(font, "Score: " + pesho.Score, new Vector2(20, 560), Color.Red);
            spriteBatch.DrawString(font, "Life: " + pesho.Life, new Vector2(180, 560), Color.Green);
            spriteBatch.DrawString(font, "Power: " + pesho.Power, new Vector2(320, 560), Color.Blue);
            spriteBatch.DrawString(font, "Magic: " + pesho.Magic, new Vector2(480, 560), Color.Purple);

            pesho.Draw(spriteBatch, new Vector2(pesho.X, pesho.Y));

        }
    }
}