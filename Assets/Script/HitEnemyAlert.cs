using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyAlert : MonoBehaviour
{
    bool isHit;
    private bool hitMonster = false;
    private bool GetHide;
    float timer = 10f;
    void Start()
    {
       
        GetHide = GameObject.Find("Interact").GetComponent<Hide>().GetisHiding();
    }
    private void Update()
    {
        Duration();
    }
    public void Alert()
    {
        hitMonster = true;
    }
    public bool GeHitted()
    {
        return isHit;
    }
    void Duration()
    {
        
        if (hitMonster)
        {
            timer -= Time.deltaTime;
            if (timer == 0f || GetHide)
            {
                hitMonster = false;
            }
        }
    }
}
