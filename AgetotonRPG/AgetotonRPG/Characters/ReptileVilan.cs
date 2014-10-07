using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    class ReptileVilan: Character
    {
        public ReptileVilan(int life, int power, int magic)
            : base(life, power, magic)
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
            this.Life += 30;
            this.Power += 5;
            this.Magic += 40;
        }

        public override void Damage()
        {
            this.Life -= 20;
        }
    }
}
