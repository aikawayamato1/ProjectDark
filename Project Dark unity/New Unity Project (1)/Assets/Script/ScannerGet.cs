﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGet : MonoBehaviour
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
            mover.HaveScanner();
            Destroy(gameObject);
        }

    }
}