using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField][Range(1, 5)] private int wavesCount = 1;
    [SerializeField][Range(1, 6)] private int level = 1;
    [SerializeField][Range(0, 2)] private float fakeGameSpeed = 1;
    /*[SerializeField] private float matchTime = 0;
    [SerializeField] private float matchMaximumTime = 1500;
    [SerializeField] private float roundTime = 0;
    [SerializeField] private float roundMaximumTime = 300;*/
    [SerializeField] private float waveTime = 0;
    [SerializeField] private float waveMaximumTime = 60;
    [SerializeField] private float bonusTime = 0;
    [SerializeField] private float bonusMaximumTime = 15;
    [SerializeField][Range(1, 1.20f)] private float bonusMultiplier = 1;
    [SerializeField] private float intervalBetweenWaves = 5f;

    public static WavesManager instance;

    private void Awake()
    {
        if (instance == null) // If there is no instance already
        {
            instance = this;
        }
        else if (instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    void Start()
    {
        //GameEvents.instance.onMatchStart += WaveStart;
        GameEvents.instance.onRoundStart += RoundStart;
        //GameEvents.instance.onWaveStart += WaveStart;
        GameEvents.instance.onBonusStart += BonusStart;
    }


    void Update()
    {
        
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetWave()
    {
        return wavesCount;
    }

    public float GetMultiplier()
    {
        return bonusMultiplier;
    }

    private void RoundStart()
    {
        WaveStart();
    }

    private void WaveStart()
    {
        GameEvents.instance.WaveStart();
        StartCoroutine(WaveTimer());
    }

    IEnumerator WaveTimer()
    {
        waveTime = 0;


        while(waveTime < waveMaximumTime)
        {
            waveTime += 1;
            yield return new WaitForSeconds(fakeGameSpeed);
        }

        wavesCount++;
        GameEvents.instance.WaveEnd();
        VerifyWave();
    }

    private void BonusStart()
    {
        StartCoroutine(BonusTimer());
    }

    IEnumerator BonusTimer()
    {
        
        while (bonusTime < bonusMaximumTime)
        {
            bonusTime += 1;
            yield return new WaitForSeconds(fakeGameSpeed);
        }

        bonusMultiplier += 0.05f;
        bonusTime = 0;
        GameEvents.instance.BonusEnd();
        
        GameManager.instance.UpdateGameState(GameState.Playing);
    }

    private void VerifyWave()
    {
        if(wavesCount % 6 == 0)
        {
            GameEvents.instance.RoundEnd();
            StartCoroutine(IntervalRounds());
        }
        else
        {
            WaveStart();
        }
    }

    private GameState NextState()
    {
        if (level == 5)
        {
            return GameState.BossFight;
        }
        else
        {
            level++;
            wavesCount = 1;
            return GameState.BonusRound;
        }
    }

    private IEnumerator IntervalRounds()
    {
        float time = 0;
        while (time < intervalBetweenWaves)
        {
            time++;
            yield return new WaitForSeconds(1);
        }
        
        GameManager.instance.UpdateGameState(NextState());
    }


}
