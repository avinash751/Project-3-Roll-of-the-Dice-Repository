using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaExplosion : MonoBehaviour
{
    public bool Triggered;
    public int ExplosionDamage;

    private void Start()
    {
        float explosionScale = FindObjectOfType<Bazzooka>().ExplosionSize;
        transform.localScale = new Vector3(explosionScale, explosionScale, explosionScale);
    }
    private void OnTriggerEnter(Collider other)
    {
        List<GameObject> enemyList = new List<GameObject>();
        enemyList.Add(other.gameObject);

        for(int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i].tag == "Enemy")
            {
                foreach(GameObject enemy in enemyList)
                {
                    enemy.GetComponent<IDamagable>().TakeDamage(ExplosionDamage);
                   // Debug.Log(enemy.name + "enemy destroyed");
                }
            }
        }

        DestroyExplosion();
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }


}
