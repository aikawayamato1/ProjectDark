using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulbBait : MonoBehaviour
{
    public Text Ammo;
    public Text itemname;
    public int bullet = 1;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    private void OnEnable()
    {
        itemname.text = "Bulb Bait";
    }
    private void OnDisable()
    {
        itemname.text = "--";

    }
    Ray putbait;
    RaycastHit hit;
    public GameObject objectToSpawn;
    // Update is called once per frame
    void Update()
    {
        putbait = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(putbait, out hit, 10f))
        {
            if(Input.GetMouseButtonDown(0)&& bullet>0)
            {
                Instantiate(objectToSpawn, hit.point, Quaternion.identity);
                bullet--;
            }
        }
        Ammo.text = bullet + "/1";
    }
}
