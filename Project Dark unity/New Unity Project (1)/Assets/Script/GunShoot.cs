using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public int bullet = 10;
    public Camera fpscam;
    public Text Ammo;
    public Text itemname;
    public GameObject impactEffect;

    private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        
    }
    private void OnEnable()
    {
        itemname.text = "Gun";
    }
    // Update is called once per frame
    void Update()
    {
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
           GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
        bullet--;
    }
    
}
