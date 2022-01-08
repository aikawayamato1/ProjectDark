using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int maxhealth = 3;
    public GameObject deadScreen;
    private GameObject AudioSourcePlayer;
    public AudioManager am;


    private void Start()
    {
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
    }
    public void healthminus()
    {
        health--;
       
    }
    private void Update()
    {
        if(health <= 0)
        {
            am.died();
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
        am.Healing();
        if(health<maxhealth)
        {
            health++;
        }
        


    }
    IEnumerator WaitforDead(float time)
    {
        yield return new WaitForSeconds(time); 
    }
   
}
