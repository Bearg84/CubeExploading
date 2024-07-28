using UnityEngine;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    private List<GameObject> _newCubes = new List<GameObject>();

    public void SetNewCubes(List<GameObject> newCubes)
    {
        _newCubes = newCubes;
    }

    public void ApplyExplosionForce(Vector3 explosionPosition)
    {
        foreach (GameObject cube in _newCubes)
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

        _newCubes.Clear();
    }
}