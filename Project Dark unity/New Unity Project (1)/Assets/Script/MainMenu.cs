using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
      
        
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void training()
    {

    }
    public void Options()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
