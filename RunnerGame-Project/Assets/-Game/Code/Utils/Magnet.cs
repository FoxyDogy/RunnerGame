using System.Collections.Generic;
using UnityEngine;

public class Magnet
{
    public ForceMode forceMode = ForceMode.Force;

    public void Grab(Vector3 position, float radius, float grabForce)
    {
        var colliders = Physics.OverlapSphere(position, radius);
        for (var i = 0; i < colliders.Length; i++)
            if (colliders[i].TryGetComponent(out Rigidbody rb))
            {
                var position1 = rb.position;
                var direction = (position - position1).normalized;
                var distance = Vector3.Distance(position, position1);
                rb.AddForce(direction * (distance * grabForce), forceMode);
            }
    }

    public void Grab(Vector3 position, float radius, float grabForce, LayerMask layerMask)
    {
        var colliders = Physics.OverlapSphere(position, radius, layerMask);
        for (var i = 0; i < colliders.Length; i++)
            if (colliders[i].TryGetComponent(out Rigidbody rb))
            {
                var position1 = rb.position;
                var direction = (position - position1).normalized;
                var distance = Vector3.Distance(position, position1);
                rb.AddForce(direction * (distance * grabForce), forceMode);
            }
    }

    public void Grab(Vector3 position, float radius, float grabForce, out Rigidbody[] bodies)
    {
        var colliders = Physics.OverlapSphere(position, radius);
        var rigidbodies = new List<Rigidbody>();
        for (var i = 0; i < colliders.Length; i++)
            if (colliders[i].TryGetComponent(out Rigidbody rb))
            {
                var position1 = rb.position;
                var direction = (position - position1).normalized;
                var distance = Vector3.Distance(position, position1);
                rb.AddForce(direction * (distance * grabForce), forceMode);
                rigidbodies.Add(rb);
            }

        bodies = rigidbodies.ToArray();
    }

    public void Grab(Vector3 position, float radius, float grabForce, LayerMask layerMask, out Rigidbody[] bodies)
    {
        var colliders = Physics.OverlapSphere(position, radius, layerMask);
        var rigidbodies = new List<Rigidbody>();
        for (var i = 0; i < colliders.Length; i++)
            if (colliders[i].TryGetComponent(out Rigidbody rb))
            {
                var position1 = rb.position;
                var direction = (position - position1).normalized;
                var distance = Vector3.Distance(position, position1);
                rb.AddForce(direction * (distance * grabForce), forceMode);
            }

        bodies = rigidbodies.ToArray();
    }
}