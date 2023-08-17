using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StrategyPattern
{
    public class Client : MonoBehaviour
    {
        private GameObject _drone;
        private List<IManeuverBehaviour> _components = new();

        private void SpawnDrone()
        {
            _drone = GameObject.CreatePrimitive(PrimitiveType.Cube);

            _drone.AddComponent<Drone>();

            _drone.transform.position = Random.insideUnitSphere * 10;
            
            ApplyRandomStrategies();
        }

        private void ApplyRandomStrategies()
        {
            _components.Add(_drone.AddComponent<WeavingManeuver>());
            _components.Add(_drone.AddComponent<BobbingManeuver>());
            _components.Add(_drone.AddComponent<FallbackManeuver>());

            int index = Random.Range(0, _components.Count);
            
            _drone.GetComponent<Drone>().ApplyStrategy(_components[index]);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Drone"))
                SpawnDrone();
        }
    }
}