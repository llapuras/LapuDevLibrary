using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public GameObject curGo;
    private GameObject go;
    public Vector3 mousepos;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            mousepos.z = 10;

            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            go = Instantiate(curGo, mousepos, Quaternion.identity) as GameObject;
        }


    }
}
