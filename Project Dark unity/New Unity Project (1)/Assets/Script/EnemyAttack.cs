using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Player;
    public GameObject Enemies;
    
    
    
    private Movement mover;
    private PlayerHealth healths;
    private NavMeshAgent nav;
    private bool hitted = false;
    private float speed = 7f;
    public Animator anim;
    public MonsterAudio MA;
    public GameManager gm;

    
    
    private void Start()
    {
        
        nav = Enemies.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        healths = Player.GetComponent<PlayerHealth>();
        mover = Player.GetComponent<Movement>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        MA = GetComponent<MonsterAudio>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MA.PlayAttack();
            if (hitted == false)
            {

                
                StartCoroutine(WaitforAttack(4f));
            }
        }
    }
   public bool GetHitted()
    {
        return hitted;
    }
    void hitPlayer()
    {
        healths.healthminus();
        gm.ActiveEffect();
        mover.hitted();
        anim.SetBool("isAttacking", true);
        nav.speed = 0f;
        
        hitted = true;
        
        
    }
    
    IEnumerator WaitforAttack(float time)
    {
        hitPlayer();
        yield return new WaitForSeconds(time);
        anim.SetBool("isAttacking", false);
        hitted = false;
        nav.speed = speed;
        
    }
}
