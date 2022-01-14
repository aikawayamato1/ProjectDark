using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControl : MonoBehaviour
{
    public GameManager gm;
    public AudioClip mindVoices;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.ax()==4||gm.bx()==4||gm.cx()==4)
        {
            audio.clip = mindVoices;
            if (audio.isPlaying == false)
            {

                audio.Play();
            }
        }
    }
}
