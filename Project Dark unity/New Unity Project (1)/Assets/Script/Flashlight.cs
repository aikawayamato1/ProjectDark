using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    bool isOn = false;
    public GameObject lightsource;
    public KeyCode flash = KeyCode.F;
    public bool failSafe = false;
    public Text itemname;
    public Text desc;
    private GameObject AudioSourcePlayer;
    public AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
    }
    private void OnEnable()
    {
        itemname.text = "Flashlight";
        desc.text = "--";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(flash))
        {
            if(isOn == false && failSafe == false)
            {
                failSafe = true;
                lightsource.SetActive(true);
                am.Flashlights();
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightsource.SetActive(false);
                am.Flashlights();
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }
}
