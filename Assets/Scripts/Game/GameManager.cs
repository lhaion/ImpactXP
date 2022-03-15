using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string Wallet = "";
    public static GameManager instance;
    public GameState State;
    [SerializeField] private float score;
    [SerializeField] private float pot = 0;
    [SerializeField] private float tokens;
    [SerializeField] private float ticketValue = 600;
    public bool isPaused;
    public bool isFreeMode;
    [SerializeField]private bool isWalletConnected;


    public static event Action<GameState> OnGameStateChange;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            instance = this;
        }
        else if (instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
        GameEvents.instance.onWalletConnected += SetWallet;
        GameEvents.instance.onBonusEnd += AddPot;
    }

    public void SetWallet()
    {
        isWalletConnected = true;
    }

    public float GetTicketValue()
    {
        return tokens;
    }

    public bool GetWalletState()
    {
        return isWalletConnected;
    }
    public void AddTokens(float tokensBrought)
    {
        tokens += tokensBrought;
    }

    public float GetTokens()
    {
        return tokens;
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
            case GameState.MainMenu:
                HandleMainMenu();
                break;
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
            case GameState.MakeTransfer:
                HandleMakeTransfer();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);                
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandleMainMenu()
    {
        //Debug.Log("MainMenu");
        Time.timeScale = 1;
        isPaused = false;

        //tokens = GetTokens();
    }

    private void HandleIntro()
    {
        Debug.Log("Intro");
        pot = 0;
        score = 0;
        //StartCoroutine(Countdown());
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

    private void HandleGameOver()
    {
        Debug.Log("GameOver");
        GameEvents.instance.MatchEnd();
    }

    private void HandleMakeTransfer()
    {
        Debug.Log("Trying handshake");
        GameEvents.instance.TryTransaction();
        netScript.instance.MakeTransfer((int)GetPot(), Wallet);
        //GameEvents.instance.MatchEnd();
    }

    /*IEnumerator Countdown()
    {
        int count = 4;
        while (count > 0)
        {
            yield return new WaitForSeconds(1f);
            count--;
            GameEvents.instance.CountDown();
        }

        UpdateGameState(GameState.Playing);
    }*/


}

public enum GameState
{
    MainMenu,
    Intro,
    Playing,
    BonusRound,
    BossFight,
    GameOver,
    MakeTransfer
}

