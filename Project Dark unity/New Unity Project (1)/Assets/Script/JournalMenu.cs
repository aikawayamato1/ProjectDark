using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMenu : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PrintButton;
    private bool EvidencesPrintButton=false;
    private void OnEnable()
    {
        UnlockMouse();
        PrintButton.SetActive(false);
        EvidencesPrintButton = false;
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
    public void Evidence()
    {
        if(EvidencesPrintButton == false)
        {
            PrintButton.SetActive(true);
            EvidencesPrintButton = true;
        }
        else
        {
            PrintButton.SetActive(false);
            EvidencesPrintButton = false;
        }
        
    }
    public void Case()
    {

    }
    public void Equipment()
    {

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
