using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    class ReptileVilan: Character
    {
        public ReptileVilan(Texture2D texture, int rows, int columns)
            : base(texture, rows, columns)
        {

        }

        public override void Attack()
        {
            this.Power -= 15;
        }
        public override void Enchant()
        {
            this.Magic -= 20;
        }
        public override void Heal()
        {
            this.Health += 30;
            this.Power += 5;
            this.Magic += 40;
        }

        public override void Damage()
        {
            this.Health -= 20;
        }
    }
}
