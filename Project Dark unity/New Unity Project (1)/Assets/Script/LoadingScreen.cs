using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadingScreen : MonoBehaviour
{
    public float time = 10f;
    public GameObject donetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            donetext.SetActive(true);
        }
        else
        {
            donetext.SetActive(false);
        }
    }
}
