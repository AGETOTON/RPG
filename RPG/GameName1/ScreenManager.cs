using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using AgetotonRPG.GameClasses;
using AgetotonRPG.GameConstants;
using AgetotonRPG.GameEnums;

namespace AgetotonRPG
{

    public class ScreenManager
    {
        private static ScreenManager instance;

        public Vector2 Dimensions { get; private set; }

        private Texture2D background;

        private SpriteFont info;
        private SpriteFont gameOver;


        private Soldier player;
        private Enemy enemy;

        Texture2D playerTexture;
        Texture2D enemyTexture;

        private bool isNewKillAvailable = true;
        private bool canIRakeLive = true;
        private bool canIAddLives = true;

        public ScreenManager()
        {
            Dimensions = new Vector2(ScreenConstants.GAME_WINDOW_X, ScreenConstants.GAME_WINDOW_Y);
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

            this.enemyTexture = content.Load<Texture2D>("characters/blueEnemy");
            this.enemy = new Enemy(this.enemyTexture, 600, 440, EnemyComplexity.Weak);

            this.playerTexture = content.Load<Texture2D>("characters/solider");
            this.player = new Soldier
                (this.playerTexture, ScreenConstants.START_PLAYER_POSITION_X, ScreenConstants.POSTION_CREATURE_Y);

            this.player.Target = this.enemy;
            this.enemy.Target = this.player;

            this.enemyTexture = content.Load<Texture2D>("characters/blueEnemy");

        }


        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            GetKeyboardInputs();
            this.enemy.Move();
            this.enemy.TryAtack();
            WatchPlayerLife();
            WatchPlayerKills();
            WatchPlayerPosition();
        }
        private void GetKeyboardInputs()
        {
            KeyboardState currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Right) && currentState.IsKeyDown(Keys.Space))
            {
                this.player.JumpRight();
            }
            if (currentState.IsKeyDown(Keys.Left) && currentState.IsKeyDown(Keys.Space))
            {
                this.player.JumpLeft();
            }
            if (currentState.IsKeyDown(Keys.Space))
            {
                this.player.JumpUp();
            }
            if (currentState.IsKeyDown(Keys.Right))
            {
                this.player.WalkRight();
            }
            if (currentState.IsKeyDown(Keys.Left))
            {
                this.player.WalkLeft();
            }
            if (currentState.IsKeyUp(Keys.Space))
            {
                this.player.AllowJump();
            }
            if (currentState.IsKeyDown(Keys.X))
            {
                this.player.Shoot();
            }
            if (currentState.IsKeyUp(Keys.Right) &&
                currentState.IsKeyUp(Keys.Left) &&
                currentState.IsKeyUp(Keys.X))
            {
                this.player.AllowShoot();
                this.player.StartWalkFrame();
            }
        }

        private void CreateNewEnemy()
        {
            Random rnd = new Random();

            Thread thread = new Thread(() =>
            {
                Thread.Sleep(100);
                int complexiti = rnd.Next(0, 3);
                float coordinates = rnd.Next(300, 700);
                if (this.player.Kills < 20)
                {
                    this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Weak);
                }
                else if (this.player.Kills < 40 && this.player.Kills > 20)
                {
                    this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Average);
                }
                else
                {
                    this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Strong);
                }

                this.enemy.Target = this.player;
                this.player.Target = this.enemy;
            });
            thread.Start();
            if (this.isNewKillAvailable)
            {
                this.player.Kills++;
                this.isNewKillAvailable = false;
            }
        }

        private void WatchPlayerLife()
        {
            if (this.player.Health <= 0)
            {
                this.player.Lives--;
                this.player.Health = SoldierConstants.START_HEALTH;
                RespownPlayer();
            }
        }

        private void WatchPlayerKills()
        {
            if (this.player.Kills % 15 == 0 && this.player.Kills > 0 && this.canIAddLives)
            {
                this.player.Lives++;
                this.canIAddLives = false;
            }
            else if(this.player.Kills % 15 != 0)
            {
                this.canIAddLives = true;
            }
        }

        private void WatchPlayerPosition()
        {
            if (this.player.Y == ScreenConstants.POSTION_CREATURE_Y)
            {
                if (this.player.X >= 70 && this.player.X <= 90 || this.player.X >= 272 && this.player.X <= 280)
                {
                    Thread thread = new Thread(() =>
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            Thread.Sleep(5);
                            this.player.Y++;
                        }

                        RespownPlayer();
                    }
                    );
                    thread.Start();

                    if (this.canIRakeLive)
                    {
                        this.canIRakeLive = false;
                        this.player.Lives--;
                    }

                }
            }
        }
        public void RespownPlayer()
        {
            if (this.enemy.X >= 400)
            {
                this.player.X = ScreenConstants.START_SCREEN;
                this.player.Y = ScreenConstants.POSTION_CREATURE_Y;
                this.player.CanMoveRight = true;
            }
            else
            {
                this.player.X = ScreenConstants.END_SCREEN;
                this.player.Y = ScreenConstants.POSTION_CREATURE_Y;
                this.player.CanMoveLeft = true;
            }

            this.canIRakeLive = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.background, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.DrawString(this.info, "Health: " + this.player.Health, new Vector2(20, 10), Color.Red);
            spriteBatch.DrawString(this.info, "Lives: " + this.player.Lives, new Vector2(20, 40), Color.YellowGreen);

            spriteBatch.DrawString(this.info, "Enemy Health " + this.enemy.Health, new Vector2(620, 20), Color.AntiqueWhite);
            spriteBatch.DrawString(this.info, "Player Kills " + this.player.Kills, new Vector2(330, 20), Color.Azure);
            this.player.Draw(spriteBatch, new Vector2(this.player.X, this.player.Y));

            if (this.enemy.IsAlive())
            {
                this.enemy.Draw(spriteBatch, new Vector2(this.enemy.X, this.enemy.Y));
                this.isNewKillAvailable = true;
            }
            else
            {
                CreateNewEnemy();
            }

            if (this.player.Lives < 1)
            {
                spriteBatch.DrawString(this.gameOver, "GAME OVER!", new Vector2(300, 300), Color.Red);
            }
        }
    }
}