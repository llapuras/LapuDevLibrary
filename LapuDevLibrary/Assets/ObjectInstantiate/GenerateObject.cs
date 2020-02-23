using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{

    public GameObject go;
    public int GridX = 5;
    public int GridY = 5;
    public Vector3 OriginPos = new Vector3(0, 0, 0);
    public GameObject[,] Tiles;

    private float offsetX = 0;
    private float offsetY = 0;
    private float offsetZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        Tiles = new GameObject[GridX, GridY];


        if (go == null)
        {
            go = Resources.Load("GeneratedCube") as GameObject;
        }
        else if (go != null)
        {
            OriginPos = go.transform.position;
        }

        offsetX = go.transform.localScale.x;
        offsetY = go.transform.localScale.y;
        offsetZ = go.transform.localScale.z;

        for (int i = 0; i < GridX; i++)
        {
            for (int j = 0; j < GridY; j++)
            {
                Debug.Log(go.name);
                Tiles[i,j] = Instantiate(go, OriginPos + new Vector3(i * offsetX, 0, j * offsetZ), go.transform.rotation);
                Tiles[i,j].transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}