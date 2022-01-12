using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    
   
    int totalitem = 0;

    [Header("Items")]
    public GameObject[] items;
    private int i = 0;
    private bool fl;
    private bool gn;
    private bool sc;
    public int currentWeapon = 0;

    [Header("Camera")]
    public Camera fpscam;

    [Header("Game Manager")]
    public GameManager gm;

    [Header("Evidence")]
    public int totalEvidence=0;

    [Header("Text")]
    public Text A;
    public Text B;
    public Text C;
    public Text FL;
    public GameObject Interacttext;
    string itemname;

    [Header("Raycasts")]
    public float range = 100f;

    [Header("Player Health")]
    private PlayerHealth ph;

    
    [SerializeField]
    [Header("Game Object")]
    public GameObject flashlight;
    public GameObject gun;
    public GameObject scanner;
    public GameObject UltrasonicAnalyzers;





    public ItemSelector(int i)
    {
        this.i = i;
    }

    private void Start()
    {
        items = new GameObject[10];
        ph = GetComponent<PlayerHealth>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Weaponselect();
        Interactable();
        if(Input.GetKeyDown(KeyCode.E))
       {
            WeaponRay();
        }
    }
    void evidenceNames(int a, int b,int c)
    {
      
        totalEvidence++;
        if (totalEvidence == 1)
        {
            if (a == 1)
            {
                A.text = "Ultrasonic Sound Detection";
            }
            if (a == 2)
            {
                A.text = "EMF 5";
            }
            if (a == 3)
            {
                A.text = "Hiding Place: Pocket dimension";
            }
            if (a == 4)
            {
                A.text = "Mind Control Voices";
            }
            if (a == 5)
            {
                A.text = "Dead Bodies Present";
            }
            if (a == 6)
            {
                A.text = "Low Temperature";
            }
            if (a == 7)
            {
                A.text = "Tough skins";
            }
        }
        if (totalEvidence == 2)
        {
            if (b == 1)
            {
                B.text = "Ultrasonic Sound Detection";
            }
            if (b == 2)
            {
                B.text = "EMF 5";
            }
            if (b == 3)
            {
                B.text = "Pocket dimension";
            }
            if (b == 4)
            {
                B.text = "Mind Control Voices";
            }
            if (b == 5)
            {
                B.text = "Dead Bodies Present";
            }
            if (b == 6)
            {
                B.text = "Low Temperature";
            }
            if (b == 7)
            {
                B.text = "Tough skins";
            }
        }
        if (totalEvidence == 3)
        {
            if (c == 1)
            {
                C.text = "Ultrasonic Sound Detection";

            }
            if (c == 2)
            {
                C.text = "EMF 5";
            }
            if (c == 3)
            {
                C.text = "Hiding Place: Pocket dimension";
            }
            if (c == 4)
            {
                C.text = "Mind Control Voices";
            }
            if (c == 5)
            {
                C.text = "Dead Bodies Present";
            }
            if (c == 6)
            {
                C.text = "Low Temperature";
            }
            if (c == 7)
            {
                C.text = "Tough skins";
            }
        }
        
        
    }
    void WeaponRay()
    {
        RaycastHit hit;
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray,out hit,5f))
        {
            
            Debug.Log(transform.name);
            if (hit.transform.tag == "Gun")
            {
                items[totalitem] = gun;
                totalitem++;
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "Evidence")
            {
                evidenceNames(gm.ax(), gm.bx(), gm.cx());
                Destroy(hit.transform.gameObject);

            }

            if (hit.transform.tag == "flashlight")
            {
                items[totalitem] = flashlight;
                totalitem++;
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "Scanner")
            {
                items[totalitem] = scanner;
                totalitem++;
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "UltrasonicAnalyzer")
            {
                items[totalitem] = UltrasonicAnalyzers;
                totalitem++;
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.tag == "Health")
            {

                ph.healthplus();
                Destroy(hit.transform.gameObject);

            }

        }

    }
    void Interactable()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit,5f))
        {

            if(hit.transform.gameObject.layer == 13)
            {
                Interacttext.SetActive(true);
            }
            else
            {
                Interacttext.SetActive(false);
            }
            
            

        }
        if (!Physics.Raycast(ray, out hit, 5f))
        {

            

            
                Interacttext.SetActive(false);
            

        }

    }

    void Weaponselect()
    {
        for (int i = 1; i <= totalitem; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;

                SwitchWeapon(currentWeapon);

            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            currentWeapon++;
            SwitchWeapon(currentWeapon);
            if (currentWeapon > totalitem - 1)
            {
                currentWeapon = 0;
                SwitchWeapon(currentWeapon);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            currentWeapon--;
            SwitchWeapon(currentWeapon);
            if (currentWeapon < 0)
            {
                currentWeapon = totalitem;
                SwitchWeapon(currentWeapon);
            }
        }
    }

    
    void SwitchWeapon(int index)
    {

        for (int i = 0; i < totalitem; i++)
        {
            if (i == index)
            {
                items[i].gameObject.SetActive(true);
                itemname = items[i].name;
            }
            else
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
    

    public string names()
    {
        return itemname;
    }


}
