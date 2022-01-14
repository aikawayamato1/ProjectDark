using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Player;
    public GameObject Enemies;
    public GameObject UIBloodEffect;
    bool fade=false;
    private CanvasGroup Blood;
    private Movement mover;
    private PlayerHealth healths;
    private NavMeshAgent nav;
    private bool hitted = false;
    private float speed = 7f;
    public Animator anim;

    private void Update()
    {
        fadingEffect();
    }
    
    private void Start()
    {
        
        nav = Enemies.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        healths = Player.GetComponent<PlayerHealth>();
        mover = Player.GetComponent<Movement>();
        Blood = UIBloodEffect.GetComponent<CanvasGroup>();
        Blood.alpha = 0;
    }
    private void fadingEffect()
    {
      
            Blood.alpha -= Time.deltaTime;
            fade = false;
        
       
        
    }
    private void ActiveEffect()
    {
        Blood.alpha = 1;

        
            
        
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
        ActiveEffect();
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
