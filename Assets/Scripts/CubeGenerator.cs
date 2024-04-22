using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CubeGenerator : MonoBehaviour
{
    private int _minCubeCount = 2;
    private int _maxCubeCount = 6;

    public void GenerateCubes(Cube cube)
    {
        if (cube == null)
            throw new ArgumentNullException(nameof(cube));
        
        int cubeCount = Random.Range(_minCubeCount, _maxCubeCount);

        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(cube, transform.position, Quaternion.identity);
            newCube.Init();
        }
    }
}
