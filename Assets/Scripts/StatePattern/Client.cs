using UnityEngine;

namespace StatePattern
{
    public class Client : MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
                _bikeController.StartBike();

            if (GUILayout.Button("Turn Left"))
                _bikeController.Turn(BikeDirection.Left);

            if (GUILayout.Button("Turn Right"))
                _bikeController.Turn(BikeDirection.Right);

            if (GUILayout.Button("Stop Bike"))
                _bikeController.StopBike();
        }
    }
}