using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour
{
    [Header("Source")]
    public NavMeshAgent agent;
    public Transform player;
    public GameObject interact;
    public LayerMask isGround, isPlayer;

    [Header("Hide System")]
    public Hide hider;
    private bool hidingcheck;

    [Header("Variables")]
    public float round ;
    public float speed = 10.0f;
    public float acceleration = 11.0f;

    [Header("Animator")]
    public Animator anim;

    [Header("Combat")]
    public bool getShoot=false;
    public float timer=10f;
    private EnemyAttack EA;

    [Header("Audio")]
    public MonsterAudio am;
    public AudioSource audio;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("States")]
    public float sightRange;
    public bool playerInSightRange;
    public bool playerRound;
    private bool chasing;
    public GameObject LOS;

    [Header("Raycast")]
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
        am = GetComponent<MonsterAudio>();
        audio = GameObject.Find("MonsterAudio").GetComponent<AudioSource>();
        EA = GetComponent<EnemyAttack>();
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
            AudioPlaying();
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
    private void AudioPlaying()
    {
        if (transform.position.magnitude <= 0f || EA.GetHitted() == true)
        {

            am.StopPlayMusic();
        }
        else
        {
            am.PlayWalk();
            
        }
        
    }
    private void AudioPlayingRun()
    {
        if (transform.position.magnitude <= 0f || EA.GetHitted()==true)
        {

            am.StopPlayMusic();


        }
        else
        {
            am.PlayRun();
            
        }

    }
    public void ChasePlayer()
    {
        AudioPlayingRun();
        agent.SetDestination(player.transform.position);

    }
    
   
}
