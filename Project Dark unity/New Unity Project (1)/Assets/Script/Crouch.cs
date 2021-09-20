using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController controller;
    public Movement mover;
    public KeyCode nunduk = KeyCode.LeftControl;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        mover = gameObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(nunduk))
        {
            mover.Cro(7f);
            controller.height = 2f;
            
        }
        else
        {
            mover.croreturn();
            controller.height = 3.8f;
            
        }
    }
}
