using UnityEngine;

namespace StrategyPattern
{
    /// <summary>
    /// 전략 패턴에서의 Context 클래스로 간주된다.
    /// </summary>
    public class Drone : MonoBehaviour
    {
        // 광선 파라미터
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45.0f;
        private float _rayDistance = 15.0f;
        
        // 이동 파라미터
        public float speed = 1.0f;
        public float maxHeight = 5.0f;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 20.0f;

        private void Start()
        {
            _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;

            _rayDirection = Quaternion.Euler(_rayAngle, 0.0f, 0f) * _rayDirection;
        }

        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }

        private void Update()
        {
            Debug.DrawRay(transform.position, _rayDirection, Color.blue);

            if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
            {
                if (_hit.collider)
                    Debug.DrawRay(transform.position, _rayDirection, Color.green);
            }
        }
    }
}