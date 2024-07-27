using UnityEngine;

public class ExplosionManager : SingletonBase<ExplosionManager>
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ApplyExplosionForce(Vector3 explosionPosition)
    {
        CubeManager[] newCubes = FindObjectsOfType<CubeManager>();

        foreach (CubeManager cubeManager in newCubes)
        {
            Rigidbody rb = cubeManager.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
            }
        }
    }
}