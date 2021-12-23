using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed=10f;
    public float basespeed=10f;
    private Rigidbody rigidbody;
    public bool isActiveMenu;
    private bool isRegenerate =false;
    public CanvasGroup staminaslide;
    private bool mFaded=false;
    float alpha;
    bool isHiding = false;
    public AudioManager AM;
    bool running=false;

    public GameObject Canvas;
    public float jumpheight =3f;
    public bool isRunning = true;
    public float stamina = 100f;
    public float basestamina = 100f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public Hide hides;
    public bool isHidings;
    public Slider stm;
    Vector3 lastpost;
    Vector3 velocity;
    public bool isGrounded;
    bool isTouched=false;

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
        AM = GameObject.Find("AudioSourcePlayer").GetComponent<AudioManager>();
        hides = GameObject.Find("Interact").GetComponent<Hide>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        
        if (isHiding)
        {
            speed = 0f;
        }
        
        Move();
        Journal();
        Faded();
        CheckRegen();
        audioPlaying();
        
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
        if (stamina >= basestamina)
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
        //isGrounded = Physics.CheckSphere(groundcheck.position, GroundDistance, groundMask);

        // if (isGrounded && velocity.y < 0)
        // {
        //  velocity.y = -2f;
        // }
        // if (Input.GetKey(KeyCode.Space) && isGrounded)
        // {
        //      velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        // }
        


        if (isTouched)
        {
            speed =3f;
        }
        
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        
        

    }
    private void OnCollisionEnter(Collision collision)
    {
       
            if (collision.gameObject.layer==9)
            {
                isGrounded = true;
            }
        
    }
   
    private void audioPlaying()
    {
        
        if (x != 0 || z != 0 )
        {
            if (running==true)
            {
                
                AM.ChangeRun();
            }
            else
            {
                
                AM.ChangeWalk();
            }
            
        }
        else
        {
            AM.ChangeStop();
            
        }
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

        if (isRunning == true)
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && !isTouched)
            {
                running = true;
                speed = speed + 10f;
                
                if (x != 0 || z != 0)
                {
                    staminaslide.alpha += Time.deltaTime;
                    stamina-=0.5f;
                    SetStamina(stamina);
                    
                    isRegenerate = false;
                }

                





            }
        }
        
       if (Input.GetKeyUp(KeyCode.LeftShift)&& !isTouched)
        {
            running = false;
            Regeneration();
            
        }


    }
    void Regeneration()
    {
        isRunning = false;
        backtobasespeed();
        if (stamina < basestamina)
        {
            StartCoroutine(Regen(1.5f));

            
        }
    }
   
    void CheckRegen()
    {
        if (isRegenerate == true)
        {

            stamina++;
            SetStamina(stamina);
            if (stamina >= basestamina)
            {
                isRegenerate = false;
                isRunning = true;
               
            }
                
                
        }
    }

    IEnumerator Regen(float waitTime)
    {
        
        
        
            yield return new WaitForSeconds(waitTime);
            isRegenerate = true;
        
       
        
    }
    public void hitted()
    {




        
        StartCoroutine(backtoNormal(3.5f));
           
        
        
    }
    IEnumerator backtoNormal(float time)
    {

        
        isTouched = true;
        yield return new WaitForSeconds(time);
        isTouched = false;
        Debug.Log("hitted!");
        backtobasespeed();
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
        isHiding = true;
        Debug.Log("turn zero");
        speed = 0f;  
    }

    public void backtobasespeed()
    {
        isHiding = false;
        speed = basespeed;
    }
}
