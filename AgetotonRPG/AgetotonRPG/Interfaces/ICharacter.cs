namespace AgetotonRPG.Interfaces
{
    public interface ICharacter
    {
        int Lives { get; set; }

        int Health { get; set; }

        int Power { get; set; }

        int Magic { get; set; }

        bool IsAlive { get; set; }

        void Attack();

        void Enchant();

        void Heal();

        void Damage();
    }
}