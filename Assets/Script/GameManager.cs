using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Goals")]
    public int a = 0;
    public int b = 0;
    public int c = 0;
    public int randomselector;

    [Header("Winning Condition")]
    public bool x = false;
    public bool y = false;
    public bool z = false;

    public GameObject Winningcon;

    [Header("Types")]
    public bool an;
    public bool hy;
    public bool hu;
    public bool ch;

    [Header("Evidences")]
    public bool e1;
    public bool e2;
    public bool e3;
    public bool e4;
    public bool e5;
    public bool e6;
    public bool e7;
    public bool type;

    int shooted =0;

    private bool[] evidence;
    private bool isComplete;
    
    
    public EvidenceCheck ec;

    [Header("Panels")]
    public GameObject how;
    public GameObject how1;
    public GameObject how2;
    public GameObject how3;

    [Header("Etc")]
    public Text types;
    public bool HaveJournal=false;
    public GameObject BloodEffect;
    private CanvasGroup Blood;
    
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
    public GameObject getBloodEffect()
    {
        return BloodEffect;
    }
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
        Blood = BloodEffect.GetComponent<CanvasGroup>();
        Blood.alpha = 0;

        ec = GameObject.Find("EvidenceChecker").GetComponent<EvidenceCheck>();
        while (a==b|| a == c || c == b)
        {
            a = Random.Range(1, 7);
            b = Random.Range(1, 7);
            c = Random.Range(1, 7);
        }
        randomselector = Random.Range(1, 5);
        if(randomselector==1)
        {
            types.text = "Humanoid";
        }
        if (randomselector == 2)
        {
            types.text = "Chaos";
        }
        if (randomselector == 3)
        {
            types.text = "Beast";
        }
        if (randomselector == 4)
        {
            types.text = "Hybrid";
        }
        evidence = new bool[7];
    }

    private void Update()
    {
        fadingEffect();

        e1 = ec.Getbool1();
        e2 = ec.Getbool2();
        e3 = ec.Getbool3();
        e4 = ec.Getbool4();
        e5 = ec.Getbool5();
        e6 = ec.Getbool6();
        e7 = ec.Getbool7();

        


        
        an = ec.animl();
        hy = ec.hybr();
        hu = ec.hum();
        ch = ec.chs();
        
    }
    public void fadingEffect()
    {

        Blood.alpha -= Time.deltaTime;




    }
    public void ActiveEffect()
    {
        Blood.alpha = 1;




    }
    public void thereisJournal()
    {
       HaveJournal = true;
    }
    public void thereisnoJournal()
    {
        HaveJournal = false;
    }
    public bool GetJournal()
    {
        return HaveJournal;
    }
    
    public void check1()
    {
        evidence[0] = e1;
        evidence[1] = e2;
        evidence[2] = e3;
        evidence[3] = e4;
        evidence[4] = e5;
        evidence[5] = e6;
        evidence[6] = e7;
        int i = 0;
        do
        {

            if (a == i+1 && evidence[i] )
            {
                x = true;
            }
            
            if (b == i+1 && evidence[i] )
            {
                y = true;
            }
            
            if (c == i+1 && evidence[i])
            {
                z = true;
            }
            i++;
        }
        while (i <= 7);

    }
    
    
    public bool checktype()
    {
        
        
        if(randomselector==1 && hu==true)
        {
            type = true;
            
        }
        
        if (randomselector == 2 && ch == true)
        {
            type = true;
            
        }
        
        if (randomselector == 3 && an == true)
        {
            type = true;
            
        }
        
        if (randomselector == 4 && hy == true)
        {
            type = true;
            
        }
        
        return type;
    }
    public void Print()
    {

        if (x == true && y == true && z == true && type==true)
        {
            if (randomselector == 1)
            {
                
                how.SetActive(true);
            }
            if (randomselector == 2)
            {
                how1.SetActive(true);
            }
            if (randomselector == 3)
            {
                how2.SetActive(true);
            }
            if (randomselector == 4)
            {
                how3.SetActive(true);
            }

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
    public int getMonsterIndex()
    {
        return randomselector;
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
