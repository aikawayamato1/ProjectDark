using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject training;
    private void Start()
    {
      
        
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Training()
    {
        training.SetActive(true);
    }
    public void TrainingBack()
    {
        training.SetActive(false);
    }
    public void Options()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
