using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    void Start()
    {
        CreateGravityCube();
    }

    void CreateGravityCube()
    {
        int row = 70;
        int col = 70;

        for (int i = 0; i < row ; i++)
        {
            for (int j = 0; j < col ;j++)
            {
                var cube = Instantiate(cubePrefab, transform);
                //cube.transform.localPosition = new Vector3(i * 0.03f, 0, j * 0.03f);
                cube.transform.localPosition = new Vector3(i * 0.2f, 0, j * 0.2f);
            }
        }
    }
}
