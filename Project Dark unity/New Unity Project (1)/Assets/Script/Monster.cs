using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public GameObject interact;
    public LayerMask isGround, isPlayer;
    public Hide hider;
    private bool hidingcheck;
    public float round ;
    public float speed = 10.0f;
    public float acceleration = 11.0f;
    public Animator anim;
    public bool getShoot=false;
    public float timer=10f;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;
    public bool playerRound;
    private bool chasing;
    public GameObject LOS;

    private RaycastHit hit;
    public void Getshooted()
    {
        getShoot = true;
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = acceleration;
        anim = GetComponent<Animator>();
        interact = GameObject.Find("Interact");
        hider = interact.GetComponent<Hide>();
         
    }

    private void Update()
    {
        playerInSightRange = Physics.Raycast(transform.position, transform.forward, out hit, sightRange);
        playerRound = Physics.CheckSphere(transform.position, round,isPlayer);
        
        hidingcheck = hider.GetisHiding();

     
        
        if (playerInSightRange|| getShoot)
        {
            
            if (!hidingcheck)
            {
                if(getShoot)
                {
                    timer = 10f;

                    agent.speed = 5f;
                    timer -= Time.deltaTime;
                    if (timer == 0f || hider)
                    {
                        getShoot = false;
                        agent.speed = 10f;
                    }
                }

                Debug.Log("Chase");
                ChasePlayer();
                
                
            }
            else
            {
                Patroling();
            }
            
        }

        if (playerRound || getShoot)
        {

            if (!hidingcheck)
            {
                if (getShoot)
                {
                    timer = 10f;

                    agent.speed = 5f;
                    timer -= Time.deltaTime;
                    if (timer <= 0f || hider)
                    {
                        agent.speed = 10f;
                        getShoot = false;

                    }
                }
                Debug.Log("Chase");
                ChasePlayer();
                

            }
            

        }
        if (!playerRound || hidingcheck)
        {
            Patroling();
        }

        

        

        if (!playerInSightRange && !playerRound)
        {
            Patroling();
        }

        


    }
    void AnimatingWalk()
    {
        if (transform.position.magnitude <= 0f)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }
    
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            AnimatingWalk();
            agent.SetDestination(walkPoint);
            
        }
            

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
            walkPointSet = true;
    }

    public void ChasePlayer()
    {
        
        agent.SetDestination(player.transform.position);

    }
    
   
}
