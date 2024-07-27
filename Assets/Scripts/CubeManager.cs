using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private float _splitChance;
    private CubeSpawner _spawner;
    private ExplosionManager _explosionManager;

    private void Start()
    {
        SetRandomColor();
        _spawner = FindObjectOfType<CubeSpawner>();
        _explosionManager = FindObjectOfType<ExplosionManager>();
    }

    private void OnMouseDown()
    {
        if (_explosionManager != null)
        {
            _explosionManager.ApplyExplosionForce(transform.position);
        }

        if (_spawner != null)
        {
            _spawner.SpawnCubes(transform.position, transform.localScale / 2f, _splitChance);
        }

        Destroy(gameObject);
    }

    public void Initialize(float splitChance)
    {
        _splitChance = splitChance;
    }

    private void SetRandomColor()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}