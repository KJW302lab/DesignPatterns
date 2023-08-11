using UnityEngine;

namespace ObserverPattern
{
    public class Client : MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = FindObjectOfType<BikeController>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
            {
                if (_bikeController)
                    _bikeController.TakeDamage(15.0f);
            }

            if (GUILayout.Button("Toggle Turbo"))
            {
                if (_bikeController)
                    _bikeController.ToggleTurbo();
            }
        }
    }
}