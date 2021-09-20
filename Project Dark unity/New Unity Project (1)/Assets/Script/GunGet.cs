using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGet : MonoBehaviour
{
    public WeaponSelector mover;
    public GameObject FindPlayer;
    

    private void Start()
    {
        FindPlayer = GameObject.Find("Player");
        mover = FindPlayer.GetComponent<WeaponSelector>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mover.HaveGun();
            Destroy(gameObject);
        }

    }
}
