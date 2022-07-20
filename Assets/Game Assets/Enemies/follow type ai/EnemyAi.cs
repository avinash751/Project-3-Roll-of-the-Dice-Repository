using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour,IDamagable
{
    public GameObject Target;
    public float MoveSpeed;
   

    [Header("Enemy Stats")]
    public int Health;
    public int MaxHealth;
    public int Damage;
    public float PushForce;

    Rigidbody2D rb;
    void Start()
    {
        EnemyManager.instance.AddEnemyToList(this);
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;

    }
    
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        transform.position = (Vector2.MoveTowards(transform.position, Target.transform.position, MoveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int Damage)
    {
        if (Health > 0)
        {
            Health -= Damage;
            //Debug.Log("enemy taken Damage");
            
        }
        else if (Health <= 0)
        {
            //Debug.Log("enemy died");
            EnemyManager.instance.RemoveEnemyFromList(this);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null && collision.gameObject.tag != "Enemy")
        {
            damagable.TakeDamage(Damage);

        }

    }
}
