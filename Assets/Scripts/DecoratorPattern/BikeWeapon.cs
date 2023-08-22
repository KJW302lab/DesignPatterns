using System;
using System.Collections;
using UnityEngine;

namespace DecoratorPattern
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private bool _isFiring;
        private IWeapon _weapon;
        private bool _isDecorated;

        private void Start()
        {
            _weapon = new Weapon(weaponConfig);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            
            GUI.Label(new Rect(5f, 50f, 150f, 100f), $"Range : {_weapon.Range}");
            
            GUI.Label(new Rect(5f, 70f, 150f, 100f), $"Strength : {_weapon.Strength}");
            
            GUI.Label(new Rect(5f, 90f, 150f, 100f), $"Cooldown : {_weapon.Cooldown}");
            
            GUI.Label(new Rect(5f, 110f, 150f, 100f), $"Firing Rate : {_weapon.Rate}");
            
            GUI.Label(new Rect(5f, 130f, 150f, 100f), $"Weapon Firing : {_isFiring}");

            if (mainAttachment && _isDecorated)
                GUI.Label(new Rect(5f, 150f, 150f, 100f), $"Main Attachment : {mainAttachment.name}");

            if (secondaryAttachment && _isDecorated)
                GUI.Label(new Rect(5f, 170f, 2000f, 100f), $"Secondary Attachment : {secondaryAttachment.name}");
        }

        public void ToggleFire()
        {
            _isFiring = !_isFiring;

            if (_isFiring)
                StartCoroutine(nameof(FireWeapon));
        }

        IEnumerator FireWeapon()
        {
            float firingRate = 1.0f / _weapon.Rate;

            while (_isFiring)
            {
                yield return new WaitForSeconds(firingRate);
                Console.WriteLine("fire");
            }
        }

        public void Reset()
        {
            _weapon = new Weapon(weaponConfig);
            _isDecorated = !_isDecorated;
        }

        public void Decorate()
        {
            if (mainAttachment && !secondaryAttachment)
                _weapon = new WeaponDecorator(_weapon, mainAttachment);

            if (mainAttachment && secondaryAttachment)
                _weapon = new WeaponDecorator(new WeaponDecorator(_weapon, mainAttachment), secondaryAttachment);

            _isDecorated = !_isDecorated;
        }
    }
}
