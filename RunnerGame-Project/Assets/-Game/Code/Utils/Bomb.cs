using System.Collections.Generic;
using UnityEngine;

namespace Code.Utils
{
    public class Bomb
    {
        public void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier)
        {
            var collider = Physics.OverlapSphere(position, radius);
            for (var i = 0; i < collider.Length; i++)
                if (collider[i].TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
        }

        public void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            LayerMask layerMask)
        {
            var collider = Physics.OverlapSphere(position, radius, layerMask);
            for (var i = 0; i < collider.Length; i++)
                if (collider[i].TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
        }

        public void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            out Rigidbody[] bodies)
        {
            var colliders = Physics.OverlapSphere(position, radius);
            var rigidbodies = new List<Rigidbody>();
            for (var i = 0; i < colliders.Length; i++)
                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
                    rigidbodies.Add(rb);
                }

            bodies = rigidbodies.ToArray();
        }

        public void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            LayerMask layerMask, out Rigidbody[] bodies)
        {
            var colliders = Physics.OverlapSphere(position, radius, layerMask);
            var rigidbodies = new List<Rigidbody>();
            for (var i = 0; i < colliders.Length; i++)
                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
                    rigidbodies.Add(rb);
                }

            bodies = rigidbodies.ToArray();
        }
    }
}