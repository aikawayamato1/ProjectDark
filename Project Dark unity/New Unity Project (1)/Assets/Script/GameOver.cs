using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Transform Player;
    public Transform Monsters;
    Vector3 startpointPlayer;
    Vector3 startpointMonster;
    public GameObject DeadScreen;

    private void OnEnable()
    {
        UnlockMouse();
    }
    
    private void OnDisable()
    {
        lockMouse();
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void lockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Retry()
    {
        
        
        SceneManager.LoadScene(2);
    }
    public void backtoMain()
    {
        SceneManager.LoadScene(0);
    }
}
