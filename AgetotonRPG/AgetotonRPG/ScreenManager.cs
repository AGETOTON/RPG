namespace AgetotonRPG
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using AgetotonRPG.Characters;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ScreenManager
    {
        private static ScreenManager instance;

        public Vector2 Dimensions { get; private set; }

        private Texture2D background;

        private SpriteFont info;
        private SpriteFont gameOver;


        private Player player;

        private List<Enemy> enemies = new List<Enemy>();

        Texture2D playerTexture;
        Texture2D enemyTexture;


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

        public void LoadContent(ContentManager content)
        {
            this.background = content.Load<Texture2D>("backgrounds/cave");
            this.info = content.Load<SpriteFont>("fonts/BlackOpsOne");
            this.gameOver = content.Load<SpriteFont>("fonts/GameOver");

            this.playerTexture = content.Load<Texture2D>("characters/player");
            this.player = new Player(this.playerTexture, 30, 450);

            this.enemyTexture = content.Load<Texture2D>("characters/blueEnemy");
            for (int i = 0; i < 5; i++)
            {
                this.CreateEnemies();
            }
            
        }

        private void CreateEnemies()
        {
            Random randomX = new Random();
            int x = randomX.Next(600, 780);

            Random complexity = new Random();
            int level = complexity.Next(0, 2);

            this.enemies.Add(new Enemy(this.enemyTexture, x, 450, (Enemies)level));
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);

            foreach (Enemy enemy in this.enemies)
            {
                enemy.Update(gameTime);
                if (enemy.IsAlive == false)
                {
                    this.enemies.Remove(enemy);
                    this.CreateEnemies();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.background, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.DrawString(this.info, "Score: " + this.player.Score, new Vector2(20, 560), Color.Red);
            spriteBatch.DrawString(this.info, "Lives: " + this.player.Lives, new Vector2(180, 560), Color.Green);
            spriteBatch.DrawString(this.info, "Health: " + this.player.Health, new Vector2(330, 560), Color.Blue);
            spriteBatch.DrawString(this.info, "Power: " + this.player.Power, new Vector2(490, 560), Color.Aqua);
            spriteBatch.DrawString(this.info, "Magic: " + this.player.Magic, new Vector2(680, 560), Color.Purple);

            spriteBatch.DrawString(this.info, "X: " + this.player.X, new Vector2(20, 10), Color.Aqua);
            spriteBatch.DrawString(this.info, "Y: " + this.player.Y, new Vector2(180, 10), Color.Aqua);

            this.player.Draw(spriteBatch, new Vector2(this.player.X, this.player.Y));

            foreach (Enemy enemy in this.enemies)
            {
                enemy.Draw(spriteBatch, new Vector2(enemy.X, enemy.Y));
            }

            if (this.player.Lives < 1)
            {
                spriteBatch.DrawString(this.gameOver, "GAME OVER!", new Vector2(300, 300), Color.Red);
            }
        }
    }
}