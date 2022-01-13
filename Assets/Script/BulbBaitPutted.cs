using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBaitPutted : MonoBehaviour
{
    public GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gm.getMonsterIndex()==2)
        {
            gm.GetCompleteBulb();
        }
    }
}
