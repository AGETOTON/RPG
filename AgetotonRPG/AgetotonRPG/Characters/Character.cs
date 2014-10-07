using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    abstract class Character: ICharacter
    {
        public Character(int life, int power, int magic)
        {
            this.Life = life;
            this.Power = power;
            this.Magic = magic;
        }

        public int Life { get; set; }
        public int Power { get; set; }
        public int Magic { get; set; }

        public abstract void Attack();
        public abstract void Enchant();
        public abstract void Heal();
        public abstract void Damage();
    }
}
