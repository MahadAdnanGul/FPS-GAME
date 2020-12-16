using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impacts : MonoBehaviour
{
    public int damage = 10;
   public AudioSource aud;
    bool hit;
    public AudioClip Metal;
    public AudioClip Wood;
    public AudioClip Concrete;
    // Start is called before the first frame update
    void Awake()
    {
        hit = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ENEMY")
        {
            if (hit == false)
            {
                aud.Play();
                hit = true;
            }
            //Debug.Log("HIT");
            collision.gameObject.GetComponent<Enemy>().Health -= damage;
        }
        else if (collision.gameObject.tag == "Wood")
        {
            if (hit == false)
            {
                aud.PlayOneShot(Wood);
                hit = true;
            }
            //Debug.Log("HIT");
            
        }
        else if (collision.gameObject.tag == "Metal")
        {
            if (hit == false)
            {
                aud.Play();
                hit = true;
            }
            //Debug.Log("HIT");

        }
        else
        {
            if (hit == false)
            {
                aud.PlayOneShot(Concrete);
                hit = true;
            }
            //Debug.Log("HIT");
            
        }



    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            //Debug.Log("HIT");
            other.gameObject.GetComponent<Enemy>().Health -= damage;
        }
        if (hit == false)
        {
            Debug.Log("playing");
            aud.Play();
            hit = true;
        }

    }*/
}
