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
    public GameObject Scanning2;
    public GameObject Scanning3;
    public GameObject Scanning4;
    public GameObject Scanning5;
    public Text itemname;
    public GameManager gm;
    bool useable=false;

    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        Scanned.text = "--";
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    private void Update()
    {
        if (gm.ax() == 2 || gm.bx() == 2 || gm.cx() == 2)
        {
            useable = true;
        }
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
            Scanning.transform.GetComponent<Renderer>().material.color = Color.green;
            if(useable)
            {
                Scanned.text = "Level 5";
                Scanning2.transform.GetComponent<Renderer>().material.color = Color.yellow;
                Scanning3.transform.GetComponent<Renderer>().material.color = Color.blue;
                Scanning4.transform.GetComponent<Renderer>().material.color = Color.red;
                Scanning5.transform.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Scanned.text = "Alert !!";
            }
            
            am.Scanning();
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Monster")
        {
            Scanning.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanning2.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanning3.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanning4.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanning5.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanned.text = "--";
            am.ChangeStops();
        }
    }
}
