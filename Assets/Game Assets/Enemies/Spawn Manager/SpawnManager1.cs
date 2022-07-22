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



    private void Awake()
    {
       
    }

    void Start()
    {
        EnemyManager.instance.AddSpawnMangerToList(this);
        InvokeRepeating(nameof(SpawnEnemy), Spawnrate, Spawnrate);
    }

    void SpawnEnemy()
    {
        SpawnPoint = new Vector3(Random.Range(-XSpawnRandomness, XSpawnRandomness), 0, Random.Range(-ZSpawnRandomness, ZSpawnRandomness)) + transform.position;
        GameObject EnemyDuplicate = Instantiate(PrefabToSpawn, SpawnPoint, Quaternion.identity);
    }

    
    void Update()
    {
        
    }
}
