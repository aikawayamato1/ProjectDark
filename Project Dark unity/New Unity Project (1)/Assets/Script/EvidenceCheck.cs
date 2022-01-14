using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceCheck : MonoBehaviour
{
    Toggle m_Toggle;
    
    public GameManager gm;
    private bool[] ev;
    private int wincond=0;
    void Start()
    {
        m_Toggle.onValueChanged.AddListener(delegate {
            Evidence1(m_Toggle);
            Evidence2(m_Toggle);
            Evidence3(m_Toggle);
            Evidence4(m_Toggle);
            Evidence5(m_Toggle);
            Evidence6(m_Toggle);
            Evidence7(m_Toggle);
            
        });
        wincond = 0;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ev = new bool[7];
    }

    public bool animal=false;
    
    public bool e1 = false;
    public bool e2 = false;
    public bool e3 = false;
    public bool e4 = false;
    public bool e5 = false;
    public bool e6 = false;
    public bool e7 = false;
    public bool Getbool1()
    {
        return e1;
    }
    public bool Getbool2()
    {
        return e2;
    }
    public bool Getbool3()
    {
        return e3;
    }
    public bool Getbool4()
    {
        return e4;
    }
    public bool Getbool5()
    {
        return e5;
    }
    public bool Getbool6()
    {
        return e6;
    }
    public bool Getbool7()
    {
        return e7;
    }
    public void isAnimal(Toggle change)
    {
        if (change.isOn == true)
        {
            animal = true;
        }
        else
        {
            animal = false;
        }
    }
    public bool animl()
    {
        return animal;
    }
    public void Evidence1(Toggle change)
    {
        if(change.isOn==true)
        {
            e1 = true;
        }
        else
        {
            e1 = false;
        }
        gm.check();
    }
    public void Evidence2(Toggle change)
    {
        if (change.isOn == true)
        {
            e2 = true;
        }
        else
        {
            e2 = false;
        }
        gm.check();
    }
    public void Evidence3(Toggle change)
    {
        if (change.isOn == true)
        {
            e3 = true;
        }
        else
        {
            e3 = false;
        }
        gm.check();
    }
    public void Evidence4(Toggle change)
    {
        if (change.isOn == true)
        {
            e4 = true;
        }
        else
        {
            e4 = false;
        }
        gm.check();
    }
    public void Evidence5(Toggle change)
    {
        if (change.isOn == true)
        {
            e5 = true;
        }
        else
        {
            e5 = false;
        }
        gm.check();
    }
    public void Evidence6(Toggle change)
    {
        if (change.isOn == true)
        {
            e6 = true;
        }
        else
        {
            e6 = false;
        }
        gm.check();
    }
    public void Evidence7(Toggle change)
    {
        if (change.isOn == true)
        {
            e7 = true;
        }
        else
        {
            e7 = false;
        }
        gm.check();
    }
    public int getWin()
    {
        return wincond;
    }
    

}
