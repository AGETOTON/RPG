using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework.Content;
using AgetotonRPG;



namespace AgetotonRPG.Characters
{
    public class PaladinHero : Character
    {
        public PaladinHero(int life, int power, int magic, Texture2D texture, int x, int y)
            : base(life, power, magic, texture, x, y)
        {
        }

        public int Score { get; set; }

        public override void Attack()
        {
            this.Power -= 5;
        }

        public override void Enchant()
        {
            this.Magic -= 10;
        }

        public override void Heal()
        {
            this.Life += 10;
            this.Power += 10;
            this.Magic += 10;
        }

        public override void Damage()
        {
            this.Life -= 10;
        }

        public void IncrementScore()
        {
            this.Score += 10;
        }

        public override void Update(GameTime gameTime)
        {
            this.UpdateInput();
            base.CheckPosition();
            // other updates...
        }

        private void UpdateInput()
        {
            KeyboardState currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(Keys.Right))
            {
                this.X += MainSettings.PLAYER_SPEED;
                if (currentState.IsKeyUp(Keys.Space))
                {
                    if (this.CurrentPlayerFrame >= MainSettings.START_RUN_FRAME)
                    {
                        this.CurrentPlayerFrame++;
                        if (this.CurrentPlayerFrame > MainSettings.STOP_RUN_FRAME)
                        {
                            this.CurrentPlayerFrame = MainSettings.START_RUN_FRAME;
                        }
                    }
                    else
                    {
                        this.CurrentPlayerFrame = MainSettings.START_RUN_FRAME;
                    }
                }
            }

            if (currentState.IsKeyUp(Keys.Right) && currentState.IsKeyUp(Keys.Space))
            {
                this.CurrentPlayerFrame = 0;
            }

            if (currentState.IsKeyDown(Keys.Left))
            {
                this.X -= MainSettings.PLAYER_SPEED;
               
                if (this.X < 0)
                {
                    this.X = 0;
                }
            }

            if (currentState.IsKeyDown(Keys.Space))
            {
                int jumpHigh = 40;
                base.MakeJump(jumpHigh);
            }
            else if (currentState.IsKeyUp(Keys.Space))
            {
                base.AllowJump();
            }

        }
    }
}