using Foxy.Utils;
using UnityEngine;

namespace Code.Utils
{
    public class RotateBymotion : MonoBehaviour
    {
        public float rotateSpeed = 45;
        private VelocityUtil velocityUtil;

        private void Awake()
        {
            velocityUtil = new VelocityUtil(transform);
        }

        private void FixedUpdate()
        {
            velocityUtil.Update();
            var motion = velocityUtil.Motion;
            if (motion != Vector3.zero)
            {
                var targetRotation = Quaternion.LookRotation(velocityUtil.Motion.normalized);
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }
    }
}