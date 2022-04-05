using System.Collections;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class CameraController : DataBehaviour
    {
        public Transform cinematic;
        public Transform game;

        private void OnEnable()
        {
            GameController.Instance.onEndGame += CameraChangeState;
        }

        private void CameraChangeState(bool state)
        {
            var target = game;
            if (state) target = cinematic;

            StartCoroutine(SmoothMove(target.position, 1f));
            StartCoroutine(SmoothRotate(target.rotation, 1f));
        }

        private IEnumerator SmoothMove(Vector3 target, float duration)
        {
            var startingPos = transform.position;
            var finalPos = target;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startingPos, finalPos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator SmoothRotate(Quaternion targetRotation, float duration)
        {
            var currentDirection = transform.rotation;
            var finalDirection = targetRotation;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Lerp(currentDirection, finalDirection, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}