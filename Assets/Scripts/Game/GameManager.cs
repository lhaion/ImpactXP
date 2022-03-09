using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState State;
    public Difficulty Difficulty;
    [SerializeField] private float score;
    [SerializeField] private float pot;

    public static event Action<GameState> OnGameStateChange;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Intro);
        GameEvents.instance.onBonusEnd += AddPot;
    }

    // Update is called once per frame
    public void AddScore(float points)
    {
        score += points;
        GameEvents.instance.UpdateScore();
    }

    public void AddPot()
    {
        pot += score;
        score = 0;
        GameEvents.instance.UpdatePot();
    }

    public float GetScore()
    {
        return score;
    }

    public float GetPot()
    {
        return pot;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Intro:
                HandleIntro();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.BonusRound:
                HandleBonusRound();
                break;
            case GameState.BossFight:
                HandleBossFight();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);                
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandleIntro()
    {
        //Debug.Log("Intro");
        StartCoroutine(Countdown());
    }

    private void HandlePlaying()
    {
        //Debug.Log("Playing");
        GameEvents.instance.MatchStart();
    }

    private void HandleBonusRound()
    {
        //Debug.Log("Playing");
        GameEvents.instance.BonusStart();
    }

    private void HandleBossFight()
    {
        Debug.Log("Here Comes the BOSS!");
        GameEvents.instance.BossFightStart();
    }

    private void HandlePause()
    {
        //Debug.Log("Pause");

    }
    private void HandleGameOver()
    {
        Debug.Log("GameOver");

    }

    IEnumerator Countdown()
    {
        int count = 4;
        while (count > 0)
        {
            yield return new WaitForSeconds(1f);
            count--;
            GameEvents.instance.CountDown();
        }

        UpdateGameState(GameState.Playing);
    }


}

public enum GameState
{
    Intro,
    Playing,
    BonusRound,
    BossFight,
    GameOver
}

public enum Difficulty
{
    level1,
    level2,
    level3,
    level4,
    level5,
    bossFight
}
