using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public float Spawnrate;
    public GameObject PrefabToSpawn;
    Vector3 SpawnPoint;
    public float XSpawnRandomness;



    private void Awake()
    {
        EnemyManager.instance.AddSpawnMangerToList(this);
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), Spawnrate, Spawnrate);
    }

    void SpawnEnemy()
    {
        SpawnPoint = new Vector3(Random.Range(-XSpawnRandomness, XSpawnRandomness), 0, 0) + transform.position;
        GameObject EnemyDuplicate = Instantiate(PrefabToSpawn, SpawnPoint, Quaternion.identity);
     
    }

    
    void Update()
    {
        
    }
}
