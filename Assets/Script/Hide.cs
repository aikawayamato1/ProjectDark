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
    public Camera fpscam;
    public float range = 5f;
    public GameObject PlayerBody;

    public GameObject Interact;
    public bool GetisHiding()
    {
        return isHiding;
    }
    public bool GetisHidings()
    {
        return hides;
    }
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerBody = GameObject.Find("PlayerBody");
        move = Player.GetComponent<Movement>();
        
        

    }
    


    void hideFunc(GameObject other)
    {
        
        if (Canhides==true && Input.GetKeyDown(hiding)&&!isHiding)
        {
            hider(other);
            
            
        }
        else
        if (isHiding && Input.GetKeyDown(hiding))
        {

            nohide(otherObject);


        }
    }
    
    public void hider(GameObject other)
    {
        Physics.IgnoreLayerCollision(11, 12, true);


        Player.transform.position = otherObject.transform.position;
        move.turnzerospeed();


        isHiding = true;

        hides = true;
    }
    public void nohide(GameObject other)
    {
        Physics.IgnoreLayerCollision(11, 12, false);

        Player.transform.position = other.transform.position+new Vector3(-1f,0f,-1f);

        move.backtobasespeed();
        isHiding = false;



        hides = false;
    }

    // Update is called once per frame
    void Update()
    {
        hideFunc(otherObject);
        
        RaycastHit hit;
        if(!isHiding)
        {
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                
                if (hit.transform.tag == "Hide")
                {
                    Interact.SetActive(true);
                    otherObject = hit.transform.gameObject;
                    Canhides = true;
                }
                else
                {
                    Interact.SetActive(false);
                    Canhides = false;
                }
            }
            
                
            
        }
        

    }
    
}
