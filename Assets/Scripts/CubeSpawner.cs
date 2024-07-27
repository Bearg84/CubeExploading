using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private float _initialSplitChance = 1f;
    private float _splitChanceReductionFactor = 0.5f;
    private int _minCubesToSpawn = 2;
    private int _maxCubesToSpawn = 7;

    public void SpawnCubes(Vector3 position, Vector3 scale, float parentSplitChance)
    {
        int numberOfNewCubes = Random.Range(_minCubesToSpawn, _maxCubesToSpawn);

        for (int i = 0; i < numberOfNewCubes; i++)
        {
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = position;
            newCube.transform.localScale = scale;

            CubeManager newCubeManager = newCube.AddComponent<CubeManager>();
            float newSplitChance = parentSplitChance * _splitChanceReductionFactor;
            newCubeManager.Initialize(newSplitChance);

            Rigidbody rigidbody = newCube.AddComponent<Rigidbody>();
            rigidbody.useGravity = true;
        }
    }
}