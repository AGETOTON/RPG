using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgetotonRPG.Characters
{
    public interface ICharacter
    {
        void Attack();
        void Enchant();
        void Heal();
        void Damage();
    }
}
