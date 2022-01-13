using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tranquilizer : MonoBehaviour
{
    public float durationChase = 10f;
    public float damage = 10f;
    public float range = 100f;
    public int bullet = 3;
    public Camera fpscam;
    public Text Ammo;
    public Text itemname;
    public GameObject impactEffect;
    private HitEnemyAlert isHittingMonster;
    private GameObject Player;
    private GameObject Monsters;
    public GameManager gm;
    public bool cantShoot;
    public GameObject journalisOpen;
    private JournalMenu jm;
    private GameObject AudioSourcePlayer;
    public AudioManager am;


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
        itemname.text = "Tranquilizer";
    }
    private void OnDisable()
    {
        itemname.text = "--";

    }
    // Update is called once per frame
    void Update()
    {
        isHittingMonster = GameObject.Find("Gun").GetComponent<HitEnemyAlert>();
        cantShoot = gm.GetJournal();
        if (!cantShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && bullet > 0)
            {
                am.GunShooting();
                Shoot();

            }
        }




        Ammo.text = bullet + "/10";






    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Monster")
            {
                Monsters.GetComponent<Monster>().Getshooted();
                if (gm.getMonsterIndex() == 3)
                {
                    gm.GetCompleteTranquilizer();
                }
            }
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
        bullet--;
    }

}
