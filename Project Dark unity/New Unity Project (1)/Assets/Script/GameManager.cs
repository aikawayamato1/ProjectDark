using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public Text itemname;

    public GameObject Player;
    

    private WeaponSelector item;
    
    

    private void Start()
    {
      
        Player = GameObject.Find("Player");

        item = Player.GetComponent<WeaponSelector>();
       

        
    }
    private void Update()
    {
        
        
       
        itemname.text = item.names();
    }
}
