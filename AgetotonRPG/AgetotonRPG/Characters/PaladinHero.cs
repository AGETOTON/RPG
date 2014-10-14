﻿using Microsoft.Xna.Framework;
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
            // other updates...
        }

        private void UpdateInput()
        {
            KeyboardState currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(Keys.Right))
            {
                this.X += MainSettings.PLAYER_SPEED;
                if (this.CurrentFrame >= MainSettings.START_RUN_FRAME)
                {
                    this.CurrentFrame++;
                    if (this.CurrentFrame > MainSettings.STOP_RUN_FRAME)
                    {
                        this.CurrentFrame = MainSettings.START_RUN_FRAME;
                    }
                }
                else
                {
                    this.CurrentFrame = MainSettings.START_RUN_FRAME;
                }
            }

            if (currentState.IsKeyUp(Keys.Right))
            {
                this.CurrentFrame = 0;
            }

            if (currentState.IsKeyDown(Keys.Left))
            {
                this.X -= MainSettings.PLAYER_SPEED;
               
                if (this.X < 0)
                {
                    this.X = 0;
                }

            }
        }
    }
}