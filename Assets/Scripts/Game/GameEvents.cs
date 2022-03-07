using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action onUpdateScore;
    public event Action onTakeDamage;
    public event Action onCountDown;
    public event Action onMatchStart;


    public void TakeDamage()
    {
        if (onTakeDamage != null)
        {
            onTakeDamage();
        }
    }

    public void UpdateScore()
    {
        if(onUpdateScore != null)
        {
            onUpdateScore();
        }
    }

    public void CountDown()
    {
        if(onCountDown != null)
        {
            onCountDown();
        }
    }

    public void MatchStart()
    {
        if(onMatchStart != null)
        {
            onMatchStart();
        }

    }

}
