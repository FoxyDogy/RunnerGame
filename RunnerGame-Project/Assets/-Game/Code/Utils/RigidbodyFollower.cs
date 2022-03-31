using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyFollower : MonoBehaviour
{
    public Transform target;
    public float force = 300;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target)
        {
            var position = target.position;
            var position1 = transform.position;
            var direction = (position1 - position).normalized;
            var distance = Vector3.Distance(position1, position);
            rb.AddForce(-direction * (distance * force));
        }
    }
}