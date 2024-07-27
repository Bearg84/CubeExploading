using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;
    private float _initialSplitChance = 1f;
    private float _splitChance;

    private void Start()
    {
        _splitChance = _initialSplitChance;

        SetRandomColor();
    }

    private void OnMouseDown()
    {
        ApplyExplosionForce();

        _splitChance *= 0.5f;

        if (Random.value <= _splitChance)
        {
            SpawnNewCubes();
        }

        Destroy(gameObject);
    }

    private void SpawnNewCubes()
    {
        int numberOfNewCubes = Random.Range(2, 7);

        for (int i = 0; i < numberOfNewCubes; i++)
        {
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = transform.position;
            newCube.transform.localScale = transform.localScale / 2f;

            SetRandomColor(newCube);

            CubeManager newCubeManager = newCube.AddComponent<CubeManager>();
            newCubeManager._splitChance = _splitChance;
            newCubeManager._initialSplitChance = _initialSplitChance;
            newCubeManager._explosionForce = _explosionForce;
            newCubeManager._explosionRadius = _explosionRadius;

            Rigidbody rb = newCube.AddComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }

    private void ApplyExplosionForce()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.gameObject != gameObject)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private void SetRandomColor(GameObject cube = null)
    {
        GameObject targetCube = cube ?? gameObject;

        Renderer renderer = targetCube.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}