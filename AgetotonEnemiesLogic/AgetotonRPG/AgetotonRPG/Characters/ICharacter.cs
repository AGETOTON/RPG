namespace AgetotonRPG.Characters
{
    using Microsoft.Xna.Framework.Graphics;

    public interface ICharacter
    {
        int Lives { get; set; }

        int Health { get; set; }

        int Power { get; set; }

        int Magic { get; set; }

        bool IsAlive { get; set; }

        Texture2D Texture { get; set; }

        void Attack();

        void Enchant();

        void Heal();

        void Damage();
    }
}