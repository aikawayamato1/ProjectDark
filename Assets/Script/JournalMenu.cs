using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMenu : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PrintButton;
    public GameObject CanvasCase;
    public GameManager gm;
    public GameObject[] Cases;
    int totalcases=0;
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
            CaseClose();
        }
        else
        {
            PrintButton.SetActive(false);
            EvidencesPrintButton = false;
        }
        
    }
    public void Case()
    {
        CanvasCase.SetActive(true);
        PrintButton.SetActive(false);
        EvidencesPrintButton = false;
    }
    public void CaseClose()
    {
        CanvasCase.SetActive(false);
    }
    

    public void next()
    {
        for (int i = 0; i < 7; i++)
        {
            if (i == totalcases)
            {
                Cases[i].gameObject.SetActive(true);
                
            }
            else
            {
                Cases[i].gameObject.SetActive(false);
            }
        }
    }
    public void Prev()
    {
        for (int i = totalcases; i >= 0; i--)
        {
            if (i == totalcases)
            {
                Cases[i].gameObject.SetActive(true);

            }
            else
            {
                Cases[i].gameObject.SetActive(false);
            }
        }
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gm.thereisJournal();
    }
    void lockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gm.thereisnoJournal();
    }
}
