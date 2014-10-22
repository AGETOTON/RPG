namespace AgetotonRPG
{
    using System;
    using System.Collections.Generic;
    using AgetotonRPG.Characters;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;

        public Vector2 Dimensions { get; private set; }

        private Texture2D background;
        private Texture2D playerTexture;
        private Texture2D blueEnemyTexture;
        private Texture2D monsterTexture;
        private Texture2D coinTexture;
        private Texture2D aidTexture;

        private SpriteFont info;
        private SpriteFont gameOver;

        private Player player;

        private List<BlueEnemy> enemies = new List<BlueEnemy>();

        private Monster monster;

        private Coin coin;

        List<Coin> coins = new List<Coin>();

        private AidKit aid;

        private static int counter;
        private static bool isMonsterReady;
        private static bool isHealed = true;


        public ScreenManager()
        {
            this.Dimensions = new Vector2(
                MainSettings.MAIN_WINDOW_X,
                MainSettings.MAIN_WINDOW_Y);
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

            this.coinTexture = content.Load<Texture2D>("stuff/coin");
            this.CreateCoins();

            this.blueEnemyTexture = content.Load<Texture2D>("characters/blueEnemy");
            this.CreateEnemies();

            this.monsterTexture = content.Load<Texture2D>("characters/monster");
            this.monster = new Monster(this.monsterTexture, 600, 400, Enemies.Strong);

            this.aidTexture = content.Load<Texture2D>("stuff/aid");
            this.aid = new AidKit(this.aidTexture, 500, 480);
        }

        private void CreateCoins()
        {
            Random randomCoin = new Random();

            for (int i = 0; i < 5; i++)
            {
                int x = randomCoin.Next(0, 800);
                int y = randomCoin.Next(350, 400);

                this.coins.Add(new Coin(this.coinTexture, x, y));
            }
        }

        private void CreateEnemies()
        {
            Random randomEnemy = new Random();


            for (int i = 0; i < 5; i++)
            {
                int x = randomEnemy.Next(500, 800);

                int level = randomEnemy.Next(0, 2);

                this.enemies.Add(new BlueEnemy(this.blueEnemyTexture, x, 450, (Enemies)level));
            }
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);
            this.monster.Update(gameTime);
            this.Healing();

            foreach (Coin coin in this.coins)
            {
                coin.Update();
            }

            foreach (BlueEnemy enemy in this.enemies)
            {
                enemy.Update(gameTime);
                if (enemy.IsAlive == false)
                {
                    this.enemies.Remove(enemy);
                }
            }

            // create the last monster
            if (this.enemies.Count < 1 && isMonsterReady == false)
            {
                if (counter == 5)
                {
                    isMonsterReady = true;
                }
                else
                {
                    this.CreateEnemies();
                }
            }
        }

        private void Healing()
        {
            if (this.player.Health < 10)
            {
                isHealed = false;
                if ((int)this.player.X == this.aid.X)
                {
                    this.player.Heal();
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
            if (isHealed == false)
            {
                this.aid.Draw(spriteBatch);
                isHealed = true;
            }

            foreach (Coin coin in this.coins)
            {
                coin.Draw(spriteBatch, new Vector2(coin.X, coin.Y));
            }

            foreach (BlueEnemy enemy in this.enemies)
            {
                enemy.Draw(spriteBatch, new Vector2(enemy.X, enemy.Y));
            }

            if (isMonsterReady)
            {
                this.monster.Draw(spriteBatch, new Vector2(this.monster.X, this.monster.Y));
            }

            if (this.player.Lives < 1)
            {
                spriteBatch.DrawString(this.gameOver, "GAME OVER!", new Vector2(300, 300), Color.Red);
            }
        }
    }
}