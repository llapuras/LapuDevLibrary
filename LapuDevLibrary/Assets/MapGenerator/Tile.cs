using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Color originColor;
    public Color mouseonColor;
    public Color selectColor;

    public GameObject ob;


    private GameObject localGo = null;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == true)
        {         
            gameObject.GetComponent<SpriteRenderer>().color = selectColor;
        }
        else if(selected == false)
        {
            
        }    
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && localGo == null)
        {
            selected = true;
            Vector3 po = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            localGo = Instantiate(ob, po, ob.transform.rotation) as GameObject;
        }
        else if (Input.GetMouseButton(1))
        {
            selected = false;
            Destroy(localGo);
            Debug.Log(localGo);
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = mouseonColor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originColor;
    }

}
