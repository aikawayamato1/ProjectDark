using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform spawnPosition;
    [Header("MonsterObject")]
    public GameObject human;
    public GameObject beast;
    public GameObject chaos;
    public GameObject hybrid;
    [Header("Index")]
    public int index;
    [Header("Game Manager")]
    public GameManager gm;
    [Header("Timer")]
    public float time;
    
    GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        index = gm.getMonsterIndex();
        enemy = new GameObject[5];
        enemy[0] = human;
        enemy[1] = chaos;
        enemy[2] = beast;
        enemy[3] = hybrid;
        if(time!=0)
        {
            while (time > 0)
            {
                time -= Time.deltaTime;
            }
        }
        
        SpawnEnemy();
    }
    
    void SpawnEnemy()
    {
       
            Instantiate(enemy[index], spawnPosition.position, enemy[index].transform.rotation);
        
      
        
    }
}
