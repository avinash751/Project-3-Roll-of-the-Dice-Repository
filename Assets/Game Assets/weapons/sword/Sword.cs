using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int SwordDamage;
    public int Durability;
    public bool collided;
    public float CollsionCheckrate;
    



    private void OnCollisionEnter(Collision collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>(); 
        if(enemy != null && !collided)
        {
            collided = true;
            enemy.TakeDamage(SwordDamage);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(250,150,0));
            ReduceDurability();
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if (enemy != null)
        {
            EnableCollsion();
        }
    }

    void EnableCollsion()
    {
        collided = false;
    }

    

    void ReduceDurability()
    {
        if(Durability>0)
        {
            Durability--;
        }
        else if(Durability <= 0)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        
    }
}
