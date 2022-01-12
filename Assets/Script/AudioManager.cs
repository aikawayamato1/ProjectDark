using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Source")]
    public GameObject Player;
    public AudioSource PlayerAudio;
    public AudioSource ItemAudio;
    [Header("Clip")]
    public AudioClip walk;
    public AudioClip Run;
    public AudioClip shoot;
    public AudioClip Scan;
    public AudioClip analyzer;
    public AudioClip Medkit;
    public AudioClip Flashlight;
    public AudioClip dead;

    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerAudio = GetComponent<AudioSource>();
        ItemAudio = GameObject.Find("ItemAudio").GetComponent<AudioSource>();
    }
    public void died()
    {
        PlayerAudio.clip = dead;
        PlayerAudio.Play();
    }
    // Update is called once per frame
    public void ChangeWalk()
    {
        PlayerAudio.clip = walk;
        PlayerAudio.pitch = 1.5f;
        if (PlayerAudio.isPlaying==false)
        {
            
            PlayerAudio.Play();
        }
        
    }
    public void ChangeStop()
    {
        
        PlayerAudio.Stop();
    }
    public void ChangeRun()
    {
        PlayerAudio.clip = Run;
        PlayerAudio.pitch = 2.5f;
        if (PlayerAudio.isPlaying == false)
        {
           

            PlayerAudio.Play();
        }
    }
    public void GunShooting()
    {
        ItemAudio.clip = shoot;
        ItemAudio.Play();
    }
    public void Flashlights()
    {
        ItemAudio.clip = Flashlight;
        ItemAudio.Play();
    }
    public void Healing()
    {
        ItemAudio.clip = Medkit;
        ItemAudio.Play();
    }
    public void Scanning()
    {

        ItemAudio.clip = Scan;
        
        if (ItemAudio.isPlaying == false)
        {

            ItemAudio.Play();
        }

    }
    public void Analyzer()
    {

        ItemAudio.clip = analyzer;

        if (ItemAudio.isPlaying == false)
        {

            ItemAudio.Play();
        }

    }
    public void ChangeStops()
    {

        ItemAudio.Stop();
    }
}
