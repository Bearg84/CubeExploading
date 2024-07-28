using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private ExplosionManager _explosionManager;
    [SerializeField] private float _splitChanceReductionFactor = 0.5f;
    [SerializeField] private int _minCubesToSpawn = 2;
    [SerializeField] private int _maxCubesToSpawn = 6;

    private List<GameObject> _newCubes = new List<GameObject>();

    public void SpawnCubes(Vector3 position, Vector3 scale, float parentSplitChance)
    {
        _newCubes.Clear();

        float newSplitChance = parentSplitChance * _splitChanceReductionFactor;
        int numberOfNewCubes = Random.Range(_minCubesToSpawn, _maxCubesToSpawn + 1);

        for (int i = 0; i < numberOfNewCubes; i++)
        {
            GameObject newCubeInstance = Instantiate(_cubePrefab, position, Quaternion.identity);
            newCubeInstance.transform.localScale = scale;

            CubeManager newCubeManager = newCubeInstance.GetComponent<CubeManager>();
            newCubeManager.Initialize(newSplitChance, this, _explosionManager);

            Rigidbody newCubeRigidbody = newCubeInstance.GetComponent<Rigidbody>();
            if (newCubeRigidbody == null)
            {
                newCubeRigidbody = newCubeInstance.AddComponent<Rigidbody>();
            }

            _newCubes.Add(newCubeInstance);
        }

        if (_explosionManager != null)
        {
            _explosionManager.SetNewCubes(_newCubes);
        }
    }
}