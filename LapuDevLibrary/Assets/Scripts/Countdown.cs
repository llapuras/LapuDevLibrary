using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Text cdtime;
    public int cd = 20;
    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(3);
        print("WaitAndPrint " + Time.time);
    }

    IEnumerator Count()
    {
        while (cd >= 0)
        {
            yield return new WaitForSeconds(1);
            cd--;
        }
    }

    void Start()
    {
        StartCoroutine(Count());
    }

    void Update()
    {
        cdtime.text = cd.ToString();
        if (cd == 0)
        {
            Debug.Log("done");

        }
    }
}
