namespace DecoratorPattern
{
    public class WeaponDecorator : IWeapon
    {
        private readonly IWeapon _decoratedWeapon;
        private readonly WeaponAttachment _attachment;

        public WeaponDecorator(IWeapon weapon, WeaponAttachment attachment)
        {
            _attachment = attachment;
            _decoratedWeapon = weapon;
        }

        public float Range => _decoratedWeapon.Range + _attachment.Range;
        public float Rate => _decoratedWeapon.Rate + _attachment.Rate;
        public float Strength => _decoratedWeapon.Strength + _attachment.Strength;
        public float Cooldown => _decoratedWeapon.Cooldown + _attachment.Cooldown;
    }
}