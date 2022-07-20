using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance { get; private set;}

    [Header(" events info")]
    public float TimeAddon;
    public bool TimeConfirmed;
    public bool EventPlayed;
    public float TotalTimeForEvent;
    public int EventNumber;
    public int EventHealthAddon;
    public int EventDamageAddon;

    [Header(" Finding references info")]

    public List<EnemyAi> EnemyList = new List<EnemyAi>();
    public List<SpawnManager1> spawnList = new List<SpawnManager1>();


    public delegate void EnemyDiceEvent();

    public void Awake()
    {
        if(instance == null)
        {   
            instance = this;
            
        }
       
    }

    public void Start()
    {
        
       
    }

    private void Update()
    {
        PlayAnEvent();
    }

    float RequiredTimeTOPlayAnEnemyEvent()
    {
        if(!TimeConfirmed)
        {
            TimeConfirmed = true;
            EventPlayed = false;
            TotalTimeForEvent = GameManager.instance.CurrentTime + TimeAddon;
            return TotalTimeForEvent; ;
        }
        else
        {
            return TotalTimeForEvent;
        }
    }

    void PlayAnEvent()
    {
        RequiredTimeTOPlayAnEnemyEvent();

        if (!EventPlayed && GameManager.instance.CurrentTime > TotalTimeForEvent && TimeConfirmed )
        {
            EventNumber = Random.Range(1, 5);
            Debug.Log("enemy dice started");
            switch (EventNumber)
            {
                case 1:
                    IncreaseHealth();
                    break;
                case 2:
                    DecresseHealth();
                    break;
                case 3:
                    IncreaseDamage();
                    break;
                case 4:
                    DecreaseDamage();
                    break;
                default:
                    break;
                    
            }

            TimeConfirmed = false;
            EventPlayed = true;
        }
    }
    public void IncreaseHealth()
    {
        foreach(EnemyAi ai in EnemyList)
        {
            ai.Health += EventHealthAddon;
            Debug.Log("increase health");
        }
    }
    public void DecresseHealth()
    {
        foreach (EnemyAi ai in EnemyList)
        {
            ai.Health -= EventHealthAddon;
            Debug.Log("decrease health");
        }
    }

    public void IncreaseDamage()
    {
        foreach (EnemyAi ai in EnemyList)
        {
            ai.Damage += EventDamageAddon;
            Debug.Log("increase damage");
        }
    }

    public void DecreaseDamage()
    {
        foreach (EnemyAi ai in EnemyList)
        {
            ai.Damage -= EventDamageAddon;
            Debug.Log("decrease damage");
        }
    }
    public void AddEnemyToList(EnemyAi enemy)
    {
       EnemyList.Add(enemy);
    }

    public void RemoveEnemyFromList(EnemyAi enemy)
    {
        EnemyList.Remove(enemy);
    }
    public void AddSpawnMangerToList(SpawnManager1 spawn)
    {
        spawnList.Add(spawn);
    }

    public void removeSpawnMangeroList(SpawnManager1 spawn)
    {
        spawnList.Remove(spawn);
    }

}
