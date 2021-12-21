using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour
{
    public AudioClip MonsterWalk;
    public AudioClip MonsterRun;
    public AudioClip MonsterAttack;
    public AudioClip MonsterHitted;

    public AudioSource MAaction;
    public AudioSource MA;
    public GameObject AudioMons;

    void Start()
    {
        AudioMons = GameObject.Find("MonsterAudio");
        MA = AudioMons.GetComponent<AudioSource>();
        MAaction = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayWalk()
    {
        Debug.Log("isPlaying");
        MA.clip = MonsterWalk;
        if (MA.isPlaying==false)
        {
            MA.pitch = 1f;
            MA.Play();
        }
        
        
    }
    public void PlayAttack()
    {
        MAaction.clip = MonsterAttack;
        MAaction.Play();
        
    }
    public void PlayRun()
    {
        MA.clip = MonsterRun;
        if (MA.isPlaying == false)
        {
            
            MA.pitch = 2f;
            MA.Play();
        }
    }
    public void PlayHitted()
    {
        MAaction.clip = MonsterHitted;
        MAaction.Play();
    }
    public void StopPlayMusic()
    {
        if(MA.isPlaying==true)
        {
            MA.Stop();
        }
        
    }
    
}
