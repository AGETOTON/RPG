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


        public Soldier player;
        private Enemy enemy;

        Texture2D playerTexture;
        Texture2D enemyTexture;

        private bool isNewKillAvailable = true;
        private bool canIAddLives = true;
        private bool canITakeLives = true;
        private bool canIAllowJump = true;

        private double totalGameTimeInSeconds = 0;
        private double lastJumpInGame = 0;

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
            this.enemy = new Enemy(this.enemyTexture, 700, 440, EnemyComplexity.Weak);

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
            this.totalGameTimeInSeconds = gameTime.TotalGameTime.TotalSeconds;
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
                if (canIAllowJump)
                {
                    if (this.lastJumpInGame + 0.4 < this.totalGameTimeInSeconds)
                    {
                        this.lastJumpInGame = totalGameTimeInSeconds;
                        this.player.AllowJump();
                    }
                }
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
                    if (this.player.Kills == 19)
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, Bosses.Weak);
                    }
                    else
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Weak);
                    }
                }
                else if (this.player.Kills >= 20 && this.player.Kills < 40)
                {
                    if (this.player.Kills == 39)
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, Bosses.Average);
                    }
                    else
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Average);
                    }
                }
                else
                {
                    if (this.player.Kills == 60 || this.player.Kills % 8 == 0)
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, Bosses.Strong);
                    }
                    else
                    {
                        this.enemy = new Enemy(this.enemyTexture, coordinates, 440, EnemyComplexity.Strong);
                    }

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

                if (this.player.IsAlive())
                {
                    RespownPlayer();
                }
            }
        }

        private void WatchPlayerKills()
        {
            if (this.player.Kills % 15 == 0 && this.player.Kills > 0 && this.canIAddLives)
            {
                this.player.Lives++;
                this.canIAddLives = false;
            }
            else if (this.player.Kills % 15 != 0)
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
                    this.player.Fall();
                    this.canIAllowJump = false;
                    if (this.canITakeLives)
                    {
                        this.player.Lives--;
                        this.canITakeLives = false;
                    }
                    Thread thread = new Thread(() =>
                    {
                        Thread.Sleep(1200);

                        if (this.player.IsAlive())
                        {
                            RespownPlayer();
                            this.player.Health = SoldierConstants.START_HEALTH;
                        }
                        this.canIAllowJump = true;
                        this.canITakeLives = true;
                    });
                    thread.Start();
                }
            }
        }
        public void RespownPlayer()
        {
            if (this.enemy.X >= 400)
            {
                this.player.X = ScreenConstants.START_SCREEN;

                this.player.CanMoveRight = true;
            }
            else
            {
                this.player.X = ScreenConstants.END_SCREEN;

                this.player.CanMoveLeft = true;
            }

            Thread thread = new Thread(() =>
            {
                this.canIAllowJump = false;
                this.player.Y = 350;
                while (this.player.Y < ScreenConstants.POSTION_CREATURE_Y)
                {
                    Thread.Sleep(4);
                    this.player.Y++;
                }
                if (this.player.Y != ScreenConstants.POSTION_CREATURE_Y)
                {
                    this.player.Y = ScreenConstants.POSTION_CREATURE_Y;
                }
                this.canIAllowJump = true;
            });
            thread.Start();
        }

        public void CreateNewGame()
        {
            this.player = new Soldier
               (this.playerTexture, ScreenConstants.START_PLAYER_POSITION_X, ScreenConstants.POSTION_CREATURE_Y);
            this.enemy = new Enemy(this.enemyTexture, 700, 440, EnemyComplexity.Weak);

            this.player.Target = this.enemy;
            this.enemy.Target = this.player;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.background, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.DrawString(this.info, "HEALTH: " + this.player.Health, new Vector2(20, 10), Color.DarkOrange);
            spriteBatch.DrawString(this.info, "LIVES: " + this.player.Lives, new Vector2(20, 40), Color.YellowGreen);

            spriteBatch.DrawString(this.info, "Enemy Health " + this.enemy.Health, new Vector2(620, 20), Color.Red);
            spriteBatch.DrawString(this.info, "Player Kills " + this.player.Kills, new Vector2(330, 20), Color.BlanchedAlmond);
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
                spriteBatch.DrawString(this.gameOver, "GAME OVER!", new Vector2(300, 150), Color.Red);
                spriteBatch.DrawString(this.gameOver, "Press \"Space\" for new game", new Vector2(150, 500), Color.Red);
                this.enemy.StopMove();
                this.player.Die();
                KeyboardState currentState = Keyboard.GetState();
                if (currentState.IsKeyDown(Keys.Space))
                {
                    CreateNewGame();
                }

            }
        }
    }
}