using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public GameObject Player;
    public AudioSource PlayerAudio;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerAudio = Player.GetComponent<AudioSource>();
        count = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && count == 0)
        {
            PlayerAudio.volume = 0.75f;
           
        }
        if (other.tag =="Player"&& count % 2 == 0)
        {
            PlayerAudio.volume = 0.75f;
            
        }
        if (other.tag == "Player" && count % 2 == 1)
        {
            PlayerAudio.volume = 0.25f;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" )
        {
            count++;

        }
    }

}
