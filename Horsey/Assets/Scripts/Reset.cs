using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("r"))
        {
            //load the correct scene..
        }
        if(Input.GetKey("q"))
        {
            Application.Quit();
        }

    }
}
