using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    interface ICharacter
    {
        void Attack();
        void Enchant();
        void Heal();
        void Damage();
    }
}
