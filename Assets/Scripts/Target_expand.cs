﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_expand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("yes");
        gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }
}
