using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_activator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("yes");
            if(gameObject.GetComponent<Camera>().enabled)
            {
                gameObject.GetComponent<Camera>().enabled=false;
            }
            else
            {
                gameObject.GetComponent<Camera>().enabled = true;
            }
        }
    }
}
