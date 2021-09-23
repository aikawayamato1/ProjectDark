using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMenu : MonoBehaviour
{
    public GameObject Canvas;

    private void OnEnable()
    {
        UnlockMouse();
    }
    private void OnDisable()
    {
        lockMouse();
    }

    public void Exitmenu()
    {
        Canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void next()
    {
        //belum
    }
    public void Prev()
    {
        //belum
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
}
