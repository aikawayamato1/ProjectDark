using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float basespeed;
    private Rigidbody rigidbody;
    public bool isActiveMenu;

    public GameObject Canvas;
    public float jumpheight =3f;
    public bool isRunning = false;
    public float stamina = 100f;
    public float basestamina = 100f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public Slider stm;
    Vector3 lastpost;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lastpost = transform.position;
        SetMaxStamina(basestamina);
        isActiveMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Move();
        Journal();
    }
    public void Journal()
    {
        if(Input.GetKeyDown(KeyCode.Q) )
        {
          if(isActiveMenu)
            {
                JournalClosed();
            }
          else
            {
                JournalOpen();
            }
        }
        

    }
    void JournalOpen()
    {
        Canvas.SetActive(true);
        isActiveMenu= true;
    }
    void JournalClosed()
    {
        Canvas.SetActive(false);
        isActiveMenu = false;
    }
    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, GroundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    public void SetMaxStamina(float x)
    {
        stm.maxValue = x;
        stm.value = x;

    }
    public void SetStamina(float x)
    {
        stm.value = x;
    }
    public void Sprint()
    {


        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 20f;
            if(controller.velocity.magnitude > 0.0f)
            {
                stamina--;
                SetStamina(stamina);
            }

            





        }
        else
        {
            backtobasespeed();
            if (stamina < basestamina)
            {
                stamina++;
                SetStamina(stamina);
            }
        }


    }


    IEnumerator Regen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
       
    }


    public void Cro(float minusspeed)
    {
         
        if(speed>minusspeed)
        {
            speed--;
        }
    }
    public void croreturn()
    {
        speed = basespeed;
    }

    

    public void backtobasespeed()
    {
        speed = basespeed;
    }
}
