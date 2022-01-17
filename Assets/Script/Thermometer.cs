using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    
    public float range = 100f;
    public float celcius;
    public float radius;
    public Camera fpscam;
    public Text degree;
    public Text itemname;
    
    private HitEnemyAlert isHittingMonster;
    private GameObject Player;
    private GameObject Monsters;
    public GameManager gm;
    
    private GameObject AudioSourcePlayer;
    public AudioManager am;
    
    public LayerMask Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Monsters = GameObject.FindGameObjectWithTag("Monster");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        AudioSourcePlayer = GameObject.Find("AudioSourcePlayer");
        am = AudioSourcePlayer.GetComponent<AudioManager>();
    }
    private void OnEnable()
    {
        itemname.text = "Thermometer";
        
        
    }
    private void OnDisable()
    {
        itemname.text = "--";

    }
    float time;
    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        if (gm.ax() == 6 || gm.bx() == 6 || gm.cx() == 6)
        {
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range)||Physics.CheckSphere(transform.position,radius,Enemy))
            {

                
                if (hit.transform.tag == "Monster")
                {


                    StartCoroutine(minusCelcius(1f)); 
                    
                    
                }
                else
                {

                    StartCoroutine(normalCelcius(1f));

                }
                
            }
        }
        else
        {

            StartCoroutine(normalCelcius(1f));


        }
    }
    IEnumerator minusCelcius(float time)
    {
        yield return new WaitForSeconds(time);
        celcius = Random.Range(-4f, 10f);
        degree.text = "" + celcius.ToString("F2");
    }
    IEnumerator normalCelcius(float time)
    {
        yield return new WaitForSeconds(time);
        celcius = Random.Range(14f, 30f);
        degree.text = "" + celcius.ToString("F2");
    }
        
}
