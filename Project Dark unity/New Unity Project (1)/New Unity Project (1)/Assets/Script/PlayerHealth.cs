using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int maxhealth = 3;
    
    public void healthminus()
    {
        health--;
       
    }
    public void healthplus()
    {
        if(health<maxhealth)
        health++;


    }

   
}
