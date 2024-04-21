using UnityEngine;

public class RandomMaterialColorChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        GenerateRandomColor();
    }

    private void GenerateRandomColor()
    {
        _meshRenderer.material.color = Random.ColorHSV();
    }
}
