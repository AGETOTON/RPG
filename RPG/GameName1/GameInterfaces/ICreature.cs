using Microsoft.Xna.Framework.Graphics;
using AgetotonRPG.GameClasses;

namespace AgetotonRPG.GameInterfaces
{
    public interface ICreature
    {
        int Health { get; set; }

        int Damage { get; set; }

        float Speed { get; set; }

        bool IsAlive();

        Texture2D Texture { get; set; }

        Creature Target { get; set; }
    }
}
