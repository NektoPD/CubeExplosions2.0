using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private float _multiplier;

    public void Explode()
    {
        foreach(Rigidbody expodableObject in GetExpodableObjects())
        {
            float distance = Vector3.Distance(transform.position, expodableObject.transform.position);
            float forceMultiplier = 1 - (distance / _radius);

            float appliedForce = _force * forceMultiplier;
            expodableObject.AddExplosionForce(appliedForce, transform.position, _radius);
        }
    }

    public void IncreaseExplosionParameters()
    {
        if (_radius < 0 && _force < 0)
            throw new ArgumentOutOfRangeException();

        _radius *= _multiplier;
        _force *= _multiplier;
    }

    private List<Rigidbody> GetExpodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> objects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}
