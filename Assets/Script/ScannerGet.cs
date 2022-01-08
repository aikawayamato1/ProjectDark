using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGet : MonoBehaviour
{

    public GameObject FindPlayer;


    private void Start()
    {
        FindPlayer = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
        }

    }
}
