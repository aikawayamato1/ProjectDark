using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            if(Input.GetMouseButton(0))
            {
                Instantiate(objectToSpawn, hit.point, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
