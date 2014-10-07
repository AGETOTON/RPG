using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    class PaladinHero: Character
    {
        public PaladinHero(int life, int power, int magic)
            : base(life, power, magic)
        {

        }

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
    }
}
