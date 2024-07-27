using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private float _splitChance;

    private void Start()
    {
        SetRandomColor();
    }

    private void OnMouseDown()
    {
        ExplosionManager.Instance.ApplyExplosionForce(transform.position);
        CubeSpawner.Instance.SpawnCubes(transform.position, transform.localScale / 2f, _splitChance);
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