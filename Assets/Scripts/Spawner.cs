using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_enemy;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("ENEMY")==null)
        {
            GameObject enema = Instantiate<GameObject>(prefab_enemy);
            enema.transform.position = new Vector3(49f, 1f, 61f);

            GameObject enema1 = Instantiate<GameObject>(prefab_enemy);
            enema1.transform.position = new Vector3(14f, 1f, 58f);

            GameObject enema2 = Instantiate<GameObject>(prefab_enemy);
            enema2.transform.position = new Vector3(19f, 1f, 10f);
        }
    }
}
