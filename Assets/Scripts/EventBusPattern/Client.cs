using UnityEngine;

namespace EventBusPattern
{
    public class Client : MonoBehaviour
    {
        private bool _isButtonEnabled;

        private void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();

            _isButtonEnabled = true;
        }

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Stop, Restart);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Stop, Restart);
        }

        private void Restart()
        {
            _isButtonEnabled = true;
        }

        private void OnGUI()
        {
            if (!_isButtonEnabled) return;

            if (GUILayout.Button("Start Countdown"))
            {
                _isButtonEnabled = false;
                RaceEventBus.Publish(RaceEventType.CountDown);
            }
        }
    }
}