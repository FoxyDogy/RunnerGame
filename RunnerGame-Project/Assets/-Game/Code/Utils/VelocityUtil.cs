using UnityEngine;

namespace Foxy.Utils
{
    public class VelocityUtil
    {
        private readonly Transform _transform;
        private Vector3 lastPosition;

        public float speed;

        public VelocityUtil(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 Motion { get; private set; }

        public void Update()
        {
            var position = _transform.position;
            Motion = (position - lastPosition) / Time.deltaTime;
            speed = Motion.magnitude;
            lastPosition = position;
        }
    }
}