namespace AgetotonRPG.Weapons
{
    public class Weapon
    {
        private int weaponDamage;
        private Weapons weaponName;

        public Weapon(Weapons weaponName, int weaponDamage)
        {
            this.WeaponName = weaponName;
            this.WeaponDamage = weaponDamage;
        }
        public int WeaponDamage
        {
            get
            {
                return this.weaponDamage;
            }
            private set
            {
                this.weaponDamage = value;
            }
        }

        public Weapons WeaponName
        {
            get
            {
                return this.weaponName;
            }
            private set
            {
                this.weaponName = value;
            }
        }
    }
}
