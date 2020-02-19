using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{

    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        go = Resources.Load("GeneratedCube") as GameObject;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Debug.Log(go.name);
                Instantiate(go, new Vector3(i * 3, j * 3, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}