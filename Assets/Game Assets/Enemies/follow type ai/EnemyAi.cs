using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour,IDamagable
{
    public bool RunOnce;
    public float UpdateFrequency;

    [Header("Target Info")]
    [SerializeField] Transform TargetPosition;
    public string TargetTag;
    

    [Header("Enemy Stats")]
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage;
    public float MoveSpeed;
    public bool StatsChangedByEvent;
    public static bool EnableEnemyCollsion;
    public GameObject sphereCollisionObject;

    [Header("Enemy Componants")]
     public static Rigidbody rb;
    [HideInInspector] public NavMeshAgent Agent;
    private void Awake()
    {
        InitializeEverythingAtAwake();
    }
    void Start()
    {
       
        EnemyManager.instance.AddEnemyToList(this);
        
    }
    
    void Update()
    {
        Agent.speed = MoveSpeed;
        StartCoroutine(SetTargetDestination());
    }

    IEnumerator SetTargetDestination()
    {
        if(Agent.isActiveAndEnabled && gameObject.activeInHierarchy && !RunOnce)
        {
             Agent.SetDestination(GetTargetPosition());
            RunOnce = true;
            yield return new WaitForSeconds(UpdateFrequency);
            RunOnce = false;
        }
        //Debug.LogWarning( gameObject.name +"enemy object is disabled or its has ran more than once");
    }

    Vector3 GetTargetPosition()
    {
        TargetPosition = GameObject.FindGameObjectWithTag(TargetTag).GetComponent<Transform>();
        if (TargetPosition != null)
        {
            return TargetPosition.position;
        }
       // Debug.AssertFormat(TargetPosition != null, " set target position  of enemy is null");
        return Vector3.zero  ;

    }

    public void TakeDamage(int Damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= Damage;
            //Debug.Log("enemy taken Damage");
            
        }
        else if (CurrentHealth <= 0)
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

        if(damagable != null && EnableEnemyCollsion)
        {
            Debug.Log("enemy collided");
            GameObject dupliacte = Instantiate(sphereCollisionObject, collision.transform.position, Quaternion.identity);
            Destroy(dupliacte, 0.15f);
        } 
    }

    void InitializeEverythingAtAwake()
    {
        Agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        CurrentHealth = MaxHealth;
    }
}
