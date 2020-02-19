using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Color originColor;
    public Color mouseonColor;
    public Color selectColor;

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
    
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            selected = true;
        }else if (Input.GetMouseButton(1))
        {
            selected = false;
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = mouseonColor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = originColor;
    }

}
