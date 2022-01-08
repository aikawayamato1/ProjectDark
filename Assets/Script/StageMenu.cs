using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenu : MonoBehaviour
{
    
   
    public void StartGame()
    {

        SceneManager.LoadScene(2);
    }
    public void MissionSelect()
    {

        
    }
    public void Leave()
    {

        SceneManager.LoadScene(0);
    }
}
