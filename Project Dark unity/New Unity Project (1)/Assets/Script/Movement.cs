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
    private bool isRegenerate;
    public CanvasGroup staminaslide;
    private bool mFaded=false;
    float alpha;

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

    float x;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lastpost = transform.position;
        SetMaxStamina(basestamina);
        alpha = staminaslide.alpha;
        isActiveMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Move();
        Journal();
        Faded();
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
    void Faded()
    {
        if (stamina == basestamina)
        {
            staminaslide.alpha -= Time.deltaTime;
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
        
         x = Input.GetAxis("Horizontal");
         z = Input.GetAxis("Vertical");

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
            if(x!=0||z!=0)
            {
                staminaslide.alpha += Time.deltaTime;
                stamina--;
                SetStamina(stamina);
                isRegenerate = false;
            }

            





        }
        else
        {
            backtobasespeed();
            if (stamina < basestamina)
            {
                StartCoroutine(Regen(1.5f));
                if(isRegenerate ==true)
                {
                    stamina++;
                    SetStamina(stamina);
                }
                
            }
        }


    }
    

    IEnumerator Regen(float waitTime)
    {
        
        
        
            yield return new WaitForSeconds(waitTime);
            isRegenerate = true;
        
       
        
    }


    public void Cro()
    {
         
        
            speed = 3f;
        
    }
    public void croreturn()
    {
        speed = basespeed;
    }

    public void turnzerospeed()
    {

        speed = 0f;  
    }

    public void backtobasespeed()
    {
        speed = basespeed;
    }
}
