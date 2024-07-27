using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ApplyExplosionForce(Vector3 explosionPosition)
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rigidbody in allRigidbodies)
        {
            if (rigidbody.gameObject != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
            }
        }
    }
}