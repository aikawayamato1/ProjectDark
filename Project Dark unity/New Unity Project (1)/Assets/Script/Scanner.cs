using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{

    public Text Scanned;
    
    public Color colore;
    MeshRenderer renderer;
    public GameObject Scanning;
    public Text itemname;

    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        Scanned.text = "--";
    }
    private void OnEnable()
    {
        itemname.text = "Scanner";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Scanning.transform.GetComponent<Renderer>().material.color = Color.red;
            Scanned.text = "Alert !!";
        }
        else
        {
            Scanned.text = "--";
        }
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Monster")
        {
            Scanning.transform.GetComponent<Renderer>().material.color = Color.white;
            Scanned.text = "--";
        }
    }
}
