using UnityEngine;

namespace EventBusPattern
{
    public class BikeController : MonoBehaviour
    {
        private string _status;

        private void OnEnable()
        {
            // StartBike() 메서드와 StopBike() 메서드의 각각 이벤트 구독
            
            RaceEventBus.Subscribe(RaceEventType.Start, StartBike);
            
            RaceEventBus.Subscribe(RaceEventType.Stop, StopBike);
        }

        private void OnDisable()
        {
            // StartBike() 메서드와 StopBike() 메서드의 각각 이벤트 구독 해제
            
            RaceEventBus.Unsubscribe(RaceEventType.Start, StartBike);
            
            RaceEventBus.Unsubscribe(RaceEventType.Stop, StopBike);
        }

        private void StartBike()
        {
            _status = "Started";
        }

        private void StopBike()
        {
            _status = "Stopped";
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10f, 60f, 200f, 20), "BIKE STATUS: " + _status);
        }
    }
}