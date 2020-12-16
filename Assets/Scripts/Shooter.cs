using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float power = 500f;
    public AudioSource guns;
    public AudioClip Fire;
   // public Transform cam;
    
    
    public GameObject prefab_bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            guns.PlayOneShot(Fire);


            GameObject bullet = Instantiate<GameObject>(prefab_bullet);

            bullet.transform.position = Camera.main.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f)); // +new Vector3(-0.2f,0.8f+0)+new Vector3(Random.Range(-0.25f,0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f)) ;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward*power,ForceMode.Impulse);
        }
    }
    
}
