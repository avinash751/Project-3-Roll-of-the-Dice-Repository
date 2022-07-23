using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance { get; private set;}

    [Header(" Enemy Diceevents info")]
    public float TimeAddon;
    public bool TimeConfirmed;
    public bool EventPlayed;
    public float TotalTimeForEvent;
    int EventNumber;
    public float UpdateFrequency;
    bool RunOnce;
    
    [Header(" Enemy stats addon info")]
    public int EnemyHealthAddon;
    public int EnemyDamageAddon;
    public float SpawnRateAddon;
    public bool SpawnEvent;

    [Header(" Finding references info")]

    public List<EnemyAi> EnemyList = new List<EnemyAi>();
    public List<SpawnManager1> EnmeySpawnList = new List<SpawnManager1>();


    public delegate void EnemyDiceEvent ();
    public  EnemyDiceEvent EnemyEvent;

    

   
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
        RandomizeAndPickAnEvent();
        StartCoroutine(RunExistingEventTilNextOne());
    }

    float RequiredTimeTOPlayAnEnemyEvent()
    {
        if(!TimeConfirmed)
        {
            TimeConfirmed = true;
            EventPlayed = false;
            TotalTimeForEvent = GameManager.instance.CurrentTime + TimeAddon;
            return TotalTimeForEvent;
        }
        return TotalTimeForEvent;
    }

 
    void RandomizeAndPickAnEvent()
    {
        RequiredTimeTOPlayAnEnemyEvent();
        if (!EventPlayed && GameManager.instance.CurrentTime > TotalTimeForEvent  && TimeConfirmed)
        {
            ReverseEnemyAndSpawnChnages();
            EventNumber = Random.Range(1, 6);
            Debug.Log("enemy dice started");
            switch (EventNumber)
            {
                case 1:
                    RunEventOnceWithChanges(IncreaseHealth, EnemyHealthAddon = Random.Range(1, 3));
                    break;
                case 2:
                    RunEventOnceWithChanges(DecresseHealth, EnemyHealthAddon = Random.Range(1, 3));
                    break;
                case 3:
                    RunEventOnceWithChanges(IncreaseDamage, EnemyDamageAddon = Random.Range(1, 3));
                    break;
                case 4:
                    RunEventOnceWithChanges(DecreaseDamage, EnemyDamageAddon = Random.Range(1, 3));
                    break;
                case 5:
                    RunEventOnceWithChanges(IncreaseSpawnRate, SpawnRateAddon = Random.Range(0.1f, 0.8f), SpawnEvent = true);
                    break;
                default:
                    break;
            }
            TimeConfirmed = false;
            EventPlayed = true;
        }
    }

    IEnumerator RunExistingEventTilNextOne() // it will continue to call existing event till the next event randomisation
    {
        if ( GameManager.instance.CurrentTime < RequiredTimeTOPlayAnEnemyEvent() && EnemyEvent!=null && !SpawnEvent)
        {
            EnemyEvent();
            RunOnce = true;
            yield return new WaitForSeconds(UpdateFrequency);
            RunOnce = false;
            Debug.Log("all enemies and objects updated to event info");
        }
    }
    public void IncreaseHealth()
    {
        Debug.Log("increase health");
        foreach (EnemyAi ai in EnemyList)
        {
            if(!ai.StatsChangedByEvent)
            {
                ai.CurrentHealth += EnemyHealthAddon;
                ai.StatsChangedByEvent = true;
            }
        }
    }
    public void DecresseHealth()
    {
        Debug.Log("decrease health");
        foreach (EnemyAi ai in EnemyList)
        {
            if (!ai.StatsChangedByEvent)
            {
                ai.CurrentHealth -= EnemyHealthAddon;
                ai.StatsChangedByEvent = true;
            }
                
        }
    }

    public void IncreaseDamage()
    {
        Debug.Log("increase damage");
        foreach (EnemyAi ai in EnemyList)
        {
            if (!ai.StatsChangedByEvent)
            {
                ai.Damage += EnemyDamageAddon;
                ai.StatsChangedByEvent = true;
            }
        }
    }

    public void DecreaseDamage()
    {
        Debug.Log("decrease damage");
        foreach (EnemyAi ai in EnemyList)
        {
            if (!ai.StatsChangedByEvent)
            {
                ai.Damage -= EnemyDamageAddon;
                ai.StatsChangedByEvent = true;
            }
                
        }
    }

    public void IncreaseSpawnRate()
    {
        Debug.Log("spawnRateIncreased");
        foreach (SpawnManager1 spawn in EnmeySpawnList)
        {
            if (!spawn.StatsChangedByEvent)
            {
                spawn.Spawnrate -= SpawnRateAddon;
                spawn.StatsChangedByEvent= true;
            }
               
        }
    }

    public void  ReverseEnemyAndSpawnChnages()
    {
        foreach(EnemyAi ai in EnemyList)
        {
            ai.StatsChangedByEvent = false;
        }

        foreach (SpawnManager1 spawn in EnmeySpawnList)
        {
            spawn.StatsChangedByEvent = false;
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
        EnmeySpawnList.Add(spawn);
    }

    public void removeSpawnMangeroList(SpawnManager1 spawn)
    {
        EnmeySpawnList.Remove(spawn);
    }

    void RunEventOnceWithChanges<T>(EnemyDiceEvent RandomEvent,T SpecifyChange)
    {
        EnemyEvent = RandomEvent;
        RandomEvent();
    }
    void RunEventOnceWithChanges<T1,T2>(EnemyDiceEvent RandomEvent, T1 SpecifyChange,T2 SpecifyChange2)
    {
        EnemyEvent = RandomEvent;
        RandomEvent();
    }



}
