using System;
using UnityEngine;

namespace DecoratorPattern
{
    public class Client : MonoBehaviour
    {
        private BikeWeapon _bikeWeapon;
        private bool _isWeaponDecorated;

        private void Start()
        {
            _bikeWeapon = FindObjectOfType<BikeWeapon>();
        }

        private void OnGUI()
        {
            if (!_isWeaponDecorated)
            {
                if (GUILayout.Button("Decorate Weapon"))
                {
                    _bikeWeapon.Decorate();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }
            }

            if (_isWeaponDecorated)
            {
                if (GUILayout.Button("Reset Weapon"))
                {
                    _bikeWeapon.Reset();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }
            }

            if (GUILayout.Button("Toggle Fire"))
                _bikeWeapon.ToggleFire();
        }
    }
}