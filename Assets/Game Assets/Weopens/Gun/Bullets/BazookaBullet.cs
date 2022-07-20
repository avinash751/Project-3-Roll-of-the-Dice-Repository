using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaBullet : MonoBehaviour
{
    public int RocketDamage;
    public bool collided;
    public GameObject BazookaExplosion;
    

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();

        if (enemy != null && !collided)
        {
            collided = true;
            GameObject duplicate = Instantiate(BazookaExplosion,collision.transform.position,Quaternion.identity);
            enemy.TakeDamage(RocketDamage);
            Destroy(gameObject);
        }

    }

   
}
