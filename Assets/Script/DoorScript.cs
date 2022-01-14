using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;



    void Update()
    {
        //Input 
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            //Log debug
            Debug.Log("You Press F");
        }
    }

    void Pressed()
    {
        //raycast
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            // raycast door
            if (doorhit.transform.tag == "Door")
            {


                anim = doorhit.transform.GetComponentInParent<Animator>();


                opened = !opened;


                anim.SetBool("Opened", !opened);
            }
        }
    }
}