using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public AudioSource attack;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatsground;
    public LayerMask whatsplayer;

    public int attack_damage = 10;

    //patroling
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    //Attacking
    public float timebetweenattacks;
    bool alreadattacked;

    //states
    public float sightrange, attackrange;
    public bool playerinsight, playerinattackrange;
     





    public Slider health_bar;
    public float move_speed = 6f;
    public float endpoint = 6f;
    float current;
    bool forward = true;

    public int Health = 100;

    private void Awake()
    {
        player = GameObject.Find("Charecter").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        current = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //check for player in range
        playerinsight = Physics.CheckSphere(transform.position, sightrange, whatsplayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatsplayer);

        if (!playerinsight && !playerinattackrange) Patroling();
        if (playerinsight && !playerinattackrange) Chasing();
        if (playerinsight && playerinattackrange) Attacking();




        /*if(transform.position.x<=(current+endpoint)&&forward==true)
        {
            Vector3 temp = transform.position;
            temp.x += move_speed * Time.deltaTime;
            transform.position = temp;
        }
        else if(transform.position.x>=current)
        {
            forward = false;
            Vector3 temp = transform.position;
            temp.x -= move_speed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            forward = true;
        }*/

        health_bar.value = 100-Health;
        if(Health<=0)
        {
            Destroy(gameObject);
        }
    }


    void Patroling()
    {
        if (!walkpointset) Search();
        agent.SetDestination(walkpoint);

        Vector3 distance = transform.position - walkpoint;

        if(distance.magnitude<1f)
        {
            walkpointset = false;
        }
    }
    
    void Search()
    {
        float randomZ = Random.Range(-walkpointrange, walkpointrange);
        float randomX = Random.Range(-walkpointrange, walkpointrange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkpoint,-transform.up,2f,whatsground))
        {
            walkpointset = true;
        }
    }
    
    void Chasing()
    {
        agent.SetDestination(player.position);
    }

    void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadattacked)
        {
            attack.Play();
            player.GetComponent<Player_move>().player_health -= attack_damage;
            alreadattacked = true;
            Invoke(nameof(ResetAttack), timebetweenattacks);
        }

    }
    void ResetAttack()
    {
        alreadattacked = false;
    }

    

    
}
