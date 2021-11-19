using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public Text itemname;

    public GameObject Player;
    

    private ItemSelector item;
    
    

    private void Start()
    {
      
        Player = GameObject.Find("Player");

        item = Player.GetComponent<ItemSelector>();
       

        
    }
    private void Update()
    {
        
        
       
        itemname.text = item.names();
    }
}
