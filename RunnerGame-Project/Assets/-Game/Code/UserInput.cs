using UnityEngine;

namespace _Game.Code
{
    public class UserInput : MonoBehaviour
    {
        public float moveFactorX;
        private new Camera camera;
        private Vector3 lastMousePosition;
        private Vector3 mouseDelta;
        private bool pressed;

        private void Awake()
        {
            camera = Camera.main;
            lastMousePosition = Vector3.zero;
        }

        private void Update()
        {
            pressed = Input.GetMouseButton(0);
            if (Input.GetMouseButtonDown(0)) lastMousePosition = GetMousePos();
            if (!pressed) mouseDelta = Vector3.zero;
            moveFactorX = mouseDelta.x;
        }

        private void FixedUpdate()
        {
            if (pressed)
            {
                mouseDelta = (GetMousePos() - lastMousePosition) / Time.deltaTime;
                lastMousePosition = GetMousePos();
            }
        }

        private Vector3 GetMousePos()
        {
            return camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}