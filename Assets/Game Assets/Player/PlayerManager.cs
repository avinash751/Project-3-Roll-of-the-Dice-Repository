using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamagable
{
    public  static PlayerManager instance { get; private set; }

    public int Health;
    public int MaxHealth;
    public int Damage;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
           
        }
    }
    void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        if(Health> 0)
        {
            Health-= Damage;
            Debug.Log("Player taken Damage");
        }
        else if(Health<=0)
        {
            Debug.Log("Player died");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if(damagable != null)
        {
            damagable.TakeDamage(Damage);
        }

    }

    void Update()
    {
        
    }
}
