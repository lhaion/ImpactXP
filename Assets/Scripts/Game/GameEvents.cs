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
    public event Action onUpdatePot;
    public event Action onTakeDamage;
    public event Action onCountDown;
    public event Action onMatchStart;
    public event Action onMatchEnd;
    public event Action onWaveStart;
    public event Action onWaveEnd;
    public event Action onRoundStart;
    public event Action onRoundEnd;
    public event Action onBonusStart;
    public event Action onBonusEnd;
    public event Action onBossFightStart;
    public event Action onBossFightEnd;

    public void BossFightStart()
    {
        if (onBossFightStart != null)
        {
            onBossFightStart();
        }
    }

    public void BossFightEnd()
    {
        if (onBossFightEnd != null)
        {
            onBossFightEnd();
        }
    }

    public void BonusStart()
    {
        if(onBonusStart != null)
        {
            onBonusStart();
        }
    }

    public void BonusEnd()
    {
        if (onBonusEnd != null)
        {
            onBonusEnd();
        }
    }

    public void RoundStart()
    {
        if(onRoundStart != null)
        {
            onRoundStart();
        }
    }

    public void RoundEnd()
    {
        if (onRoundEnd != null)
        {
            onRoundEnd();
        }
    }

    public void WaveStart()
    {
        if(onWaveStart != null)
        {
            onWaveStart();
        }
    }

    public void WaveEnd()
    {
        if (onWaveEnd != null)
        {
            onWaveEnd();
        }
    }

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

    public void UpdatePot()
    {
        if (onUpdateScore != null)
        {
            onUpdatePot();
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
        if (onMatchStart != null)
        {
            onMatchStart();
        }

        RoundStart();
    }

    public void MatchEnd()
    {
        if (onMatchEnd != null)
        {
            onMatchEnd();
        }

    }



}
