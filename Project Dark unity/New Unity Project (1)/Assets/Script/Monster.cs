using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject Player;
    public float Distance;

    public bool isAngered;

    public NavMeshAgent monster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if (Distance <=10)
        {
            isAngered = true;
        }
        if (Distance > 10f)
        {
            isAngered = false;
        }
        if (isAngered)
        {
            monster.isStopped = false;
            monster.SetDestination(Player.transform.position);
        }

        if (!isAngered)
        {
            monster.isStopped = true;
        }
    }
}
