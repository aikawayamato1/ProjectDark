using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public float durationChase = 10f;
    public float damage = 10f;
    public float range = 100f;
    public int bullet = 10;
    public Camera fpscam;
    public Text Ammo;
    public Text itemname;
    public GameObject impactEffect;
    private HitEnemyAlert isHittingMonster;
    private GameObject Player;
    private GameObject Monsters;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Monsters = GameObject.FindGameObjectWithTag("Monster");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnEnable()
    {
        itemname.text = "Gun";
    }
    // Update is called once per frame
    void Update()
    {
        isHittingMonster = GameObject.Find("Gun").GetComponent<HitEnemyAlert>();
        if(Input.GetButtonDown("Fire1")&& bullet > 0 )
        {
            Shoot();
            
        }
        
        
            Ammo.text = bullet + "/10";
        
        
        
          
        
        
    }

    void Shoot()
    {
        RaycastHit hit;
        if( Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit,range))
        {
            
            Debug.Log(hit.transform.name);
            if(hit.transform.tag=="Monster")
            {
                Monsters.GetComponent<Monster>().Getshooted();
                gm.GetComplete();
            }
           GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
        bullet--;
    }
    
    
}
