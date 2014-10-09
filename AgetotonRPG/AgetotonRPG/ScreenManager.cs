using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AgetotonRPG
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }

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

        }
        public void UnloadContent()
        {

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
