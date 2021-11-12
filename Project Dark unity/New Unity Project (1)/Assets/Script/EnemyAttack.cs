using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Player;
    public GameObject Enemies;
    private PlayerHealth healths;
    private NavMeshAgent nav;
    private bool hitted = false;
    private float speed = 7f;
    private void Start()
    {
        
        nav = Enemies.GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        healths = Player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            if (hitted == false)
            {
                
                
                StartCoroutine(WaitforAttack(4f));
            }
        }
    }
   
    void hitPlayer()
    {
        healths.healthminus();
        nav.speed = 0f;
        
        hitted = true;
        
        
    }
    IEnumerator WaitforAttack(float time)
    {
        hitPlayer();
        yield return new WaitForSeconds(time);
        hitted = false;
        nav.speed = speed;
        
    }
}
