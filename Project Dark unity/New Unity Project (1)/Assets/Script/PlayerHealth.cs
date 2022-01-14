using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int maxhealth = 3;
    public GameObject deadScreen;
    
    public void healthminus()
    {
        health--;
       
    }
    private void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(WaitforDead(1f));
            deadScreen.SetActive(true);
        }
        else
        {
            deadScreen.SetActive(false);
        }
    }
    public void healthplus()
    {
        if(health<maxhealth)
        health++;


    }
    IEnumerator WaitforDead(float time)
    {
        yield return new WaitForSeconds(time); 
    }
   
}
