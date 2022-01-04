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
                totalEvidence++;
                if(totalEvidence==1)
                {
                    A.text = gm.ax().ToString();
                }
                if (totalEvidence == 2)
                {
                    B.text = gm.bx().ToString();
                }
                if (totalEvidence == 3)
                {
                    C.text = gm.cx().ToString();
                }
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
