using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public int player_health = 100;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float Crouch_length = 0.7f;
    public Animator crouch;
    public AudioSource source;
    public AudioClip src;

    Vector3 velocity;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_health<=0)
        {
            gameObject.GetComponent<Scenes>().main_menu();
        }
        
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if(crouch.GetBool("Crouch")&&isGrounded)
        {
            speed = 6f;
        }
        else
        {
            speed = 12f;
        }
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(((x!=0||z!=0)&&source.isPlaying==false)&&isGrounded)
        {
            source.Play();
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            source.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetAxis("Crouch")>0)
        {
            crouch.SetBool("Crouch", true);
        }
        else
        {
            crouch.SetBool("Crouch", false);
        }


    }
}
