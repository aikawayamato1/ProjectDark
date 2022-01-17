using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultrasonic : MonoBehaviour
{
    public GameManager gm;
    bool useable = false;
    private GameObject AudioSourcePlayer;
    public AudioManager am;
    public Text item_name;
    public Text analyze;
    // Start is called before the first frame update
    void Start()
    {
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    private void OnEnable()
    {
        item_name.text = "Ultrasonic Analyzer";
        analyze.text = "Low";
        Debug.Log("enabled");
    }
    private void OnDisable()
    {
        
        
        am.ChangeStops();
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.ax() == 1 || gm.bx() == 1 || gm.cx() == 1)
        {
            useable = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            
            if (useable)
            {
                analyze.text = "High";
                am.Analyzer();
            }
            else
            {
                analyze.text = "Mid";
            }

            
        }


    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Monster")
        {
            analyze.text = "Low";
            am.ChangeStops();
        }
    }
}
