using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using AgetotonRPG.GameEnums;
using AgetotonRPG.GameConstants;
using System.Threading;

namespace AgetotonRPG.GameClasses
{
    public class Enemy : Creature
    {
        public Enemy
            (Texture2D texture, float x, float y,EnemyComplexity complexity)
            :base
            (texture,x,y)
        {
            if (complexity == EnemyComplexity.Weak)
            {
                base.Health = WeakEnemyConstants.HEALTH;
                base.Damage = WeakEnemyConstants.DAMAGE;
                base.Speed = WeakEnemyConstants.SPEED;
            }
            else if(complexity == EnemyComplexity.Average)
            {
                base.Health = WeakEnemyConstants.HEALTH;
                base.Damage = WeakEnemyConstants.DAMAGE;
                base.Speed = WeakEnemyConstants.SPEED;
            }
            else if(complexity == EnemyComplexity.Strong)
            {
                base.Health = StrongEnemyConstants.HEALTH;
                base.Damage = StrongEnemyConstants.DAMAGE;
                base.Speed = StrongEnemyConstants.SPEED;
            }

            base.CurrentDirection = Direction.Left;
        }
        public override bool IsAlive()
        {
            if (base.Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void WalkLeft()
        {
            if (CanMoveLeft)
            {
                base.CurrentDirection = Direction.Left;

                base.X--;

                if (base.CurrentFrame <= EnemyFrameConstants.START_LEFT_MOVE_FRAME)
                {
                    base.CurrentFrame--;
                    if (base.CurrentFrame < EnemyFrameConstants.STOP_LEFT_MOVE_FRAME)
                    {
                        base.CurrentFrame = EnemyFrameConstants.START_LEFT_MOVE_FRAME;
                    }
                }
                else
                {
                    base.CurrentFrame = EnemyFrameConstants.START_LEFT_MOVE_FRAME;
                }
            }
        }

        public override void WalkRight()
        {
            if (CanMoveRight)
            {
                base.CurrentDirection = Direction.Right;

                base.X++;

                if (base.CurrentFrame <= EnemyFrameConstants.START_RIGHT_MOVE_FRAME)
                {
                    base.CurrentFrame--;
                    if (base.CurrentFrame < EnemyFrameConstants.STOP_RIGHT_MOVE_FRAME)
                    {
                        base.CurrentFrame = EnemyFrameConstants.START_RIGHT_MOVE_FRAME;
                    }
                }
                else
                {
                    base.CurrentFrame = EnemyFrameConstants.START_RIGHT_MOVE_FRAME;
                }
            }
        }

        public override void Move()
        {
            if (base.X < base.Target.X)
            {
                base.CurrentDirection = Direction.Right;
            }
            else if (base.X > base.Target.X)
            {
                base.CurrentDirection = Direction.Left;
            }

            switch (base.CurrentDirection)
            {
                case Direction.Right:
                    WalkRight();
                    break;
                case Direction.Left:
                    WalkLeft();
                    break;
            }
        }

        public void TryAtack()
        {
            if (base.X == base.Target.X && base.Y == base.Target.Y)
            {
                base.Target.Health -= base.Damage;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / EnemyFrameConstants.SPRITE_COLS;
            int height = this.Texture.Height / EnemyFrameConstants.SPRITE_ROWS;
            int row = this.CurrentFrame / EnemyFrameConstants.SPRITE_COLS;
            int column = this.CurrentFrame % EnemyFrameConstants.SPRITE_ROWS;

            this.SourceRectangle = new Rectangle(width * column, height * row, width, height);
            this.DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.Texture, this.DestinationRectangle, this.SourceRectangle, Color.White);
        }
    }
}
