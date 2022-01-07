using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{

    public Text Scanned;
    private GameObject AudioSourcePlayer;
    public AudioManager am;
    public Color colore;
    MeshRenderer renderer;
    public GameObject Scanning;
    public Text itemname;

    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        Scanned.text = "--";
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
    }
    private void OnEnable()
    {
        itemname.text = "Scanner";
    }
    private void OnDisable()
    {
        itemname.text = "--";
        am.ChangeStops();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Scanning.transform.GetComponent<Renderer>().material.color = Color.red;
            Scanned.text = "Alert !!";
            am.Scanning();
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Monster")
        {
            Scanning.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanned.text = "--";
            am.ChangeStops();
        }
    }
}
