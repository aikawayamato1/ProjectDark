using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hide : MonoBehaviour
{
    public KeyCode hiding = KeyCode.E;
    private GameObject Player;
    bool Canhides = false;
    bool hides = false;
    public Movement move;
    public bool isHiding =false;
    public GameObject otherObject;
    
    public GameObject PlayerBody;

    public GameObject Interact;
    public bool GetisHiding()
    {
        return isHiding;
    }
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerBody = GameObject.Find("PlayerBody");
        move = Player.GetComponent<Movement>();
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hide")
        {
            Interact.SetActive(true);
            Canhides = true;
            otherObject = other.gameObject;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hide")
        {
            Interact.SetActive(false);
            Canhides = false;
            
        }
       
    }


    void hideFunc(GameObject other)
    {
        if(Canhides==true && Input.GetKeyDown(hiding))
        {
            hider(other);
            isHiding = true;
        }
        else if (isHiding&&Input.GetKeyDown(hiding))
        {
            nohide(other);
            isHiding = false;
        }
       
    }
    
    public void hider(GameObject other)
    {
        Physics.IgnoreLayerCollision(11, 12, true);

        Player.transform.position = other.transform.position;
        move.enabled = false;
        Player.GetComponent<BoxCollider>().enabled = true;
        Player.GetComponent<Rigidbody>().isKinematic = true;
        
        hides = true;
    }
    public void nohide(GameObject other)
    {
        Physics.IgnoreLayerCollision(11, 12, false);
        
        move.enabled = true;
        Player.GetComponent<BoxCollider>().enabled = false;
        Player.GetComponent<Rigidbody>().isKinematic = false;
        
        hides = false;
    }

    // Update is called once per frame
    void Update()
    {
        hideFunc(otherObject);
    }
}
