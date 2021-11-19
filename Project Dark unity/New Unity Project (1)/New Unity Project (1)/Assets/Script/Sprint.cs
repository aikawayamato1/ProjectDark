using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprint : MonoBehaviour
{
    public Movement mover;
    public float speed = 5f;
    public float stamina = 100f;
    public float basestamina = 100f;
    public Slider stm;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Movement>();
        SetMaxStamina(basestamina);
        rigidbody = GetComponent<Rigidbody>();
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
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina!=0)
        {
                mover.Sprint();

            
                stamina--;
                SetStamina(stamina);
            
                
            
            

        }
        else
        {
            mover.backtobasespeed();
            if(stamina < basestamina)
            {
                stamina++;
                SetStamina(stamina);
            }
        }
        
    }
}
