using System.Collections;
using UnityEngine;

namespace StrategyPattern
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(nameof(Fallback), drone);
        }

        IEnumerator Fallback(Drone drone)
        {
            float time = 0;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.z = drone.fallbackDistance;

            while (true)
            {
                drone.transform.position = Vector3.Lerp(startPosition, endPosition, time/speed);

                time += Time.deltaTime;

                yield return null;
            }
        }
    }
}