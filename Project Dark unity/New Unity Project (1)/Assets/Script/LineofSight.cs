using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineofSight : MonoBehaviour
{
    public Transform player;

    public GameObject Monsters;
    public NavMeshAgent agent;
    public LayerMask isGround, isPlayer;
    private Monster monster;

    public float ChasingTime = 10f;
    Vector3 sizes;
    private float times;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private bool chase=false;

    private void Start()
    {
        monster = Monsters.GetComponent<Monster>();
        agent = monster.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        Timer();
    }
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

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
    void Timer()
    {
        times = ChasingTime;
        if(chase == false)
        {
            times -= Time.deltaTime;
            if(times <= 0)
            {
                Patroling();
            }
        }
    }
    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            //monster.ChasePlayer();
            chase = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            chase = false;
            
        }
    }
    
}
