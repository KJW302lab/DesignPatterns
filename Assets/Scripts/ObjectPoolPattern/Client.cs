using UnityEngine;

namespace ObjectPoolPattern
{
    public class Client : MonoBehaviour
    {
        private DroneObjectPool _pool;

        private void Start()
        {
            _pool = gameObject.AddComponent<DroneObjectPool>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Drones"))
                _pool.Spawn();
        }
    }
}