using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    private Cube _cube;
    private int _minCubeCount = 2;
    private int _maxCubeCount = 6;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void GenerateCube()
    {
        int cubeCount = Random.Range(_minCubeCount, _maxCubeCount);

        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_cube.GetCube, transform.position, Quaternion.identity);
            newCube.Init();
        }
    }
}
