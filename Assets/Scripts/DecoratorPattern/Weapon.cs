namespace DecoratorPattern
{
    public class Weapon : IWeapon
    {
        public float Range => _config.Range;
        public float Rate => _config.Rate;
        public float Strength => _config.Strength;
        public float Cooldown => _config.Cooldown;

        private readonly WeaponConfig _config;

        public Weapon(WeaponConfig weaponConfig)
        {
            _config = weaponConfig;
        }
    }
}