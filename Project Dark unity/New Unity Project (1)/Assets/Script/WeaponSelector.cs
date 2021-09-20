using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    int weaponselected = 20;
    public bool Flashlight = false;
    public bool Gun= false;
    public bool Scanner = false;
    int totalitem = 0;
    int i = 0;

    public Text FL;

    string itemname;


    [SerializeField]
    GameObject flashlight, gun, scanner;




    public bool ActiveWeapon = false;
    


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponselected!=1)
            {
                SwapWeapon(1);
                weaponselected = 1;
                FL.text = "--";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponselected != 2)
            {
                SwapWeapon(2);
                weaponselected = 2;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponselected != 3)
            {
                SwapWeapon(3);
                weaponselected = 3;
                
            }
        }
    }

    void SwapWeapon(int weapontype)
    {
        if(weapontype==1 && Flashlight ==true)
        {
            gun.SetActive(false);
            flashlight.SetActive(true);
            scanner.SetActive(false);
            itemname = "Flashlight";
        }
        if (weapontype == 2 && Gun == true)
        {
            flashlight.SetActive(false);
            scanner.SetActive(false);
            gun.SetActive(true);
            itemname = "Gun";
        }
        if (weapontype == 3 && Scanner == true)
        {
            flashlight.SetActive(false);
            gun.SetActive(false);
            scanner.SetActive(true);
            itemname = "Scanner";
        }
    }
    public void Haveflashlight()
    {
        Flashlight = true;
    }
    public void HaveGun()
    {
        Gun = true;
        
       
        
    }
    
    public void HaveScanner()
    {
        Scanner = true;
        
        
        
    }

    public string names()
    {
        return itemname;
    }
    
    

    
}
