using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public float Spawnrate;
    public GameObject PrefabToSpawn;
    Vector3 SpawnPoint;
    public float XSpawnRandomness;
    public float ZSpawnRandomness;
    public bool StatsChangedByEvent;
    bool RunOnce;


    private void Awake()
    {
       
    }

    void Start()
    {
        EnemyManager.instance.AddSpawnMangerToList(this);
    }

    IEnumerator SpawnEnemy()
    {
        if(!RunOnce)
        {
            RunOnce = true;
            SpawnPoint = new Vector3(Random.Range(-XSpawnRandomness, XSpawnRandomness), 0, Random.Range(-ZSpawnRandomness, ZSpawnRandomness)) + transform.position;
            GameObject EnemyDuplicate = Instantiate(PrefabToSpawn, SpawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(Spawnrate);
            RunOnce = false;
        } 
    }

    
    void Update()
    {
        StartCoroutine(SpawnEnemy());   
    }
}
