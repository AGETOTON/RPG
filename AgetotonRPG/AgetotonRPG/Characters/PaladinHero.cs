using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace AgetotonRPG.Characters
{
    public class PaladinHero : Character
    {
        public PaladinHero(int life, int power, int magic, Texture2D texture, int rows, int columns)
            : base(life, power, magic, texture, rows, columns)
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
    }
}