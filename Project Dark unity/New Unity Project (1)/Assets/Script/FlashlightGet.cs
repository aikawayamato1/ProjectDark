using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightGet : MonoBehaviour
{
    // Start is called before the first frame update
    
    public WeaponSelector game;
    public GameObject FindPlayer;

    private void Start()
    {
        FindPlayer = GameObject.Find("Player");
        game = FindPlayer.GetComponent<WeaponSelector>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            game.Haveflashlight();
            Destroy(gameObject);
        }
        
    }
}
