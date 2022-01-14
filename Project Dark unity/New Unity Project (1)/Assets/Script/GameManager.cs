using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int a=0;
    public int b=0;
    public int c=0;

    public GameObject Winningcon;

    public bool an;

    public int a1 = 0;
    public int b2 = 0;
    public int c3 = 0;
    public int d4 = 0;
    public int E5 = 0;
    public int f6 = 0;
    public int g7 = 0;

    public bool e1;
    public bool e2;
    public bool e3;
    public bool e4;
    public bool e5;
    public bool e6;
    public bool e7;
    int shooted =0;

    private bool isComplete;

    public int winning=0;
    public EvidenceCheck ec;
    public GameObject how;
    //public static GameManager instance;
    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //        instance = this;
    //       DontDestroyOnLoad(gameObject);
    //    }
    //     else if (instance != null && instance != this)
    //    {
    //     Destroy(this.gameObject);
    //    }

    // }
    public void GetComplete()
    {
        if(isComplete)
        {
            if(shooted==3)
            {
                GameEnd();
            }
            else
            {
                shooted++;
            }
            
        }
        
    }
    private void Start()
    {
        
        winning = 0;
        ec = GameObject.Find("EvidenceChecker").GetComponent<EvidenceCheck>();
        while (a==b|| a == c || c == b)
        {
            a = Random.Range(1, 7);
            b = Random.Range(1, 7);
            c = Random.Range(1, 7);
        }
        
    }
    private void Update()
    {
        e1 = ec.Getbool1();
        e2 = ec.Getbool2();
        e3 = ec.Getbool3();
        e4 = ec.Getbool4();
        e5 = ec.Getbool5();
        e6 = ec.Getbool6();
        e7 = ec.Getbool7();
        an = ec.animl();
    }
    public void check()
    {
        if (a == 1 || b == 1 || c == 1 && e1)
        {
            winning++;
           
        }
        if (a == 2 || b == 2 || c == 2 && e2)
        {
            winning++;
            
        }
        if (a == 3 || b == 3 || c == 3 && e3)
        {
            winning++;
            
        }
        if (a == 4 || b == 4 || c == 4 && e4)
        {
            winning++;
           
        }
        if (a == 5 || b == 5 || c == 5 && e5)
        {
            winning++;
            
        }
        if (a == 6 || b == 6 || c == 6 && e6)
        {
            winning++;
            
        }
        if (a == 7 || b == 7 || c == 7 && e7)
        {
            winning++;
            
        }

    }
    public void Print()
    {
        
        if(winning>=3 && an==true)
        {
            how.SetActive(true);
            isComplete = true;
        }
    }
    public void back()
    {
        how.SetActive(false);
    }
    public void GameEnd()
    {
        Winningcon.SetActive(true);
    }

    public int ax()
    {
        return a;
    }
    public int bx()
    {
        return b;
    }
    public int cx()
    {
        return c;
    }

}
