using UnityEngine;

public class CubeSpawner : SingletonBase<CubeSpawner>
{
    [SerializeField] private GameObject _cubePrefab;
    private float _splitChanceReductionFactor = 0.5f;
    private int _minCubesToSpawn = 2;
    private int _maxCubesToSpawn = 7;

    public void SpawnCubes(Vector3 position, Vector3 scale, float parentSplitChance)
    {
        int numberOfNewCubes = Random.Range(_minCubesToSpawn, _maxCubesToSpawn);

        for (int i = 0; i < numberOfNewCubes; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, position, Quaternion.identity);
            newCube.transform.localScale = scale;

            CubeManager newCubeManager = newCube.GetComponent<CubeManager>();
            float newSplitChance = parentSplitChance * _splitChanceReductionFactor;
            newCubeManager.Initialize(newSplitChance);
        }
    }
}