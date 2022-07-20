using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    public static RuleManager instance { get; private set; }

    public float timeadd;
    public bool timecomfirmed;
    public bool eventplayed;
    public float TotalTimeForEvent;
    public float Eventnumber;
    private float resetevent;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playevent();
    }

    float RequiredTime()
    {
        if (!timecomfirmed)
        {
            Debug.Log("time");
            timecomfirmed = true;
            eventplayed = false;
            TotalTimeForEvent = GameManager.instance.CurrentTime + timeadd;
            return TotalTimeForEvent;
        }
        else
        {
            return TotalTimeForEvent;
        }

    }

    void playevent()
    {
        RequiredTime();

        if (!eventplayed && GameManager.instance.CurrentTime > TotalTimeForEvent && timecomfirmed)
        {
            resetall();
            Eventnumber = Random.Range(1, 4);
            resetevent = Eventnumber;
            Debug.Log("rule dice started");

            switch (Eventnumber)
            {
                case 1:
                    lowgravity();
                    break;
                case 2:
                    nomovement();
                    break;
                case 3:
                    nojumping();
                    break;             
            }
            timecomfirmed = false;
            eventplayed = true;



        }

    }
    void resetall()
    {
        player.jump = true;
        player.gravity = 1.0f;
        player.move = true;
    }

    public void lowgravity()
    {
        player.gravity = 0.3f;
        Debug.Log("low gravity");
    }
    public void nomovement()
    {
        player.move = false;
        Debug.Log("no movement");
    }
    public void nojumping()
    {
        player.jump = false;
        Debug.Log("NO JUMPING");
    }

}
