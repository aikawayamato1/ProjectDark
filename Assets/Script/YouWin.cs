using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    private void OnEnable()
    {
        UnlockMouse();
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        lockMouse();
        Time.timeScale = 1f;
    }
    void lockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void retry()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenus()
    {
        SceneManager.LoadScene(0);
    }
}
