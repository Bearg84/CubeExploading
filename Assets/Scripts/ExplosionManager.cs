using UnityEngine;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ApplyExplosionForce(Vector3 explosionPosition, List<CubeManager> newCubes)
    {
        foreach (CubeManager cube in newCubes)
        {
            if (cube != null)
            {
                Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

                if (cubeRigidbody != null)
                {
                    cubeRigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
                }
            }
        }
    }
}