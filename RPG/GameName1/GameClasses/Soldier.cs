using System;

using Microsoft.Xna.Framework.Graphics;

using AgetotonRPG.GameEnums;
using AgetotonRPG.GameConstants;
using AgetotonRPG.GameInterfaces;

using Microsoft.Xna.Framework;
using System.Threading;

namespace AgetotonRPG.GameClasses
{
    public class Soldier : Creature, IJump, IShootable
    {
        private int lives;

        private int playerCurrentFrame;
        private int lastFrame = 0;

        private bool isJumpAvailable = true;
        private bool isShootAvailable = true;

        public int Kills { get; set; }

        public Soldier
            (Texture2D texture, float x, float y)
            : base
            (texture, x, y)
        {
            base.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
            base.CurrentDirection = SoldierConstants.START_DIRECTION;
            base.Health = SoldierConstants.START_HEALTH;
            base.Damage = SoldierConstants.DAMAGE;
            base.Speed = SoldierConstants.SPEED;

            this.lives = SoldierConstants.START_LIVES;
            this.playerCurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;

        }
        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }

        public override bool IsAlive()
        {
            if (this.lives > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartWalkFrame()
        {
            if (base.CurrentDirection == Direction.Right)
            {
                if (this.lastFrame == SoldierFramesConstants.BEGIN_RIGHT_LEG_STEP_RIGHT_SIDE)
                {
                    base.CurrentFrame = SoldierFramesConstants.STEP_RIGHT_LEG_RIGHT_SIDE;
                }
                else if (this.lastFrame == SoldierFramesConstants.BEGIN_LEFT_LEG_STEP_RIGHT_SIDE)
                {
                    base.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                }

            }
            else if (base.CurrentDirection == Direction.Left)
            {
                if (this.lastFrame == SoldierFramesConstants.BEGIN_LEFT_LEG_STEP_LEFT_SIDE)
                {
                    base.CurrentFrame = SoldierFramesConstants.STEP_LEFT_LEG_LEFT_SIDE;
                }
                else if (this.lastFrame == SoldierFramesConstants.BEGIN_RIGHT_LEG_STEP_LEFT_SIDE)
                {
                    base.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                }
            }
        }

        public override void WalkRight()
        {
            if (CanMoveRight)
            {
                base.X += base.Speed;
                CheckSoldierPosition();
                base.CurrentDirection = Direction.Right;
                if (base.CurrentFrame >= SoldierFramesConstants.START_RIGHT_WALK_FRAME)
                {
                    base.CurrentFrame++;
                    if (base.CurrentFrame > SoldierFramesConstants.STOP_RIGHT_WALK_FRAME)
                    {
                        base.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                    }
                }
                else
                {
                    base.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                }

                this.lastFrame = base.CurrentFrame;
            }
        }

        public override void WalkLeft()
        {
            if (CanMoveLeft)
            {
                base.X -= base.Speed;
                base.CurrentDirection = Direction.Left;
                CheckSoldierPosition();
                if (base.CurrentFrame >= SoldierFramesConstants.START_LEFT_WALK_FRAME)
                {
                    base.CurrentFrame++;
                    if (base.CurrentFrame > SoldierFramesConstants.STOP_LEFT_WALK_FRAME)
                    {
                        base.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                    }
                }
                else
                {
                    base.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                }
                this.lastFrame = base.CurrentFrame;
            }
        }

        private void CheckSoldierPosition()
        {
            if (base.X > ScreenConstants.END_SCREEN)
            {
                base.CanMoveRight = false;
            }
            else
            {
                base.CanMoveRight = true;
            }
            if (base.X < ScreenConstants.START_SCREEN)
            {
                base.CanMoveLeft = false;
            }
            else
            {
                base.CanMoveLeft = true;
            }
        }

        public void AllowJump()
        {
            this.isJumpAvailable = true;
        }
        public void Die()
        {
            base.CanMoveLeft = false;
            base.CanMoveRight = false;
            this.isShootAvailable = false;
        }
        public void JumpUp()
        {
            if (this.isJumpAvailable)
            {
                base.Y -= SoldierConstants.JUMP_HEIGTH;

                this.isJumpAvailable = false;

                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(180);
                    base.Y += SoldierConstants.JUMP_HEIGTH;

                    if (base.CurrentDirection == Direction.Right)
                    {
                        base.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                    }
                    else
                    {
                        base.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                    }
                });
                thread.Start();
            }
        }

        public void JumpRight()
        {
            if (this.isJumpAvailable)
            {
                base.Y -= SoldierConstants.JUMP_HEIGTH;
                base.X += SoldierConstants.JUMP_WIDTH;

                this.isJumpAvailable = false;

                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(180);
                    this.Y += SoldierConstants.JUMP_HEIGTH;
                    this.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                });
                thread.Start();
            }
        }

        public void JumpLeft()
        {
            if (this.isJumpAvailable)
            {
                this.Y -= SoldierConstants.JUMP_HEIGTH;
                this.X -= SoldierConstants.JUMP_WIDTH;

                this.isJumpAvailable = false;

                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(180);
                    this.Y += SoldierConstants.JUMP_HEIGTH;
                    this.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                });
                thread.Start();
            }
        }

        public void AllowShoot()
        {
            this.isShootAvailable = true;
        }

        public void Shoot()
        {
            if (this.isShootAvailable)
            {
                if (base.CurrentDirection == Direction.Right)
                {
                    base.CurrentFrame = SoldierFramesConstants.SHOOT_RIGHT_FRAME;

                    if (base.X > ScreenConstants.START_SCREEN)
                    {
                        base.X -= 3; // this here is the recoil otkata
                    }

                    isShootAvailable = false;
                    Thread thread = new Thread(() =>
                    {
                        Thread.Sleep(60);
                        this.CurrentFrame = SoldierFramesConstants.START_RIGHT_WALK_FRAME;
                    });

                    thread.Start();

                    if (base.Target.IsAlive())
                    {
                        if (base.X < base.Target.X)
                        {
                            base.Target.Health -= base.Damage;
                        }
                    }

                }
                else if (base.CurrentDirection == Direction.Left)
                {
                    base.CurrentFrame = SoldierFramesConstants.SHOOT_LEFT_FRAME;
                    isShootAvailable = false;

                    if (base.X < ScreenConstants.END_SCREEN)
                    {
                        base.X += 3; // this here is the recoil otkata
                    }

                    Thread thread = new Thread(() =>
                    {
                        Thread.Sleep(60);
                        this.CurrentFrame = SoldierFramesConstants.START_LEFT_WALK_FRAME;
                    });
                    thread.Start();

                    if (base.Target.IsAlive())
                    {
                        if (base.X > base.Target.X)
                        {
                            base.Target.Health -= base.Damage;
                        }
                    }
                }
            }
        }
        public void Fall()
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Thread.Sleep(3);
                    base.Y++;
                }
            }
            );
            thread.Start();
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = base.Texture.Width / SoldierFramesConstants.SPRITE_COLS;
            int height = base.Texture.Height / SoldierFramesConstants.SPRITE_ROWS;
            int row = base.CurrentFrame / SoldierFramesConstants.SPRITE_COLS;
            int column = base.CurrentFrame % SoldierFramesConstants.SPRITE_COLS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            Thread.Sleep(70);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}
