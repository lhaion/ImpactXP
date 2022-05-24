using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class UIManager : MonoBehaviour
{
    public GameObject introScreen;
    public GameObject gameOverlay;

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject settingsPanel;
    public GameObject quitPanel;
    public GameObject transactionPanel;
    public GameObject gameOverPanel;
    public GameObject matchOverlay;
    public GameObject bossOverlay;
    public GameObject[] lifeCounter;
    public GameObject newWavePanel;
    public GameObject scoreTextObject;
    public Slider bossLifeBar;

    public TMPro.TMP_Text transactionText;
    public TMPro.TMP_Text finalPotText;
    public TMPro.TMP_Text finalTokensText;
    public TMPro.TMP_Text transactionButtonText;
    public TMPro.TMP_Text gameOverButtonText;
    public TMPro.TMP_Text levelCounter;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text potText;
    public TMPro.TMP_Text countdownText;
    public TMPro.TMP_Text newWaveText;
    public GameObject transactionButton;
    public GameObject gameOverButton;
    public GameObject gameOverFreeButton;
    public GameObject resumeGameButton;
    public GameObject settingsButton;
    public GameObject quitButton;
    public GameObject cancelQuitButton;
    public GameObject confirmQuitButton;
    public GameObject senseSlider;
    
    //public UnityEngine.UI.

    private PlayerManager thisPlayer;

    void Awake()
    {
        thisPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onTakeDamage += TakeDamage;
        GameEvents.instance.onUpdateScore += UpdadeScore;
        GameEvents.instance.onUpdatePot += UpdadePot;
        GameEvents.instance.onCountDown += CountDown;
        GameEvents.instance.onMatchStart += MatchStart;
        GameEvents.instance.onMatchEnd += MatchEnd;
        GameEvents.instance.onWaveStart += WaveStart;
        GameEvents.instance.onBonusStart += BonusStart;
        GameEvents.instance.onBossFightStart += BossFightStart;
        GameEvents.instance.onPauseGame += PauseGame;
        GameEvents.instance.onResumeGame += ResumeGame;
        GameEvents.instance.onTransferSuccessful += TransactionConfirmed;
        GameEvents.instance.onTransferFailed += TransactionFailed;

        introScreen.SetActive(true);
    }
    
    

    public void SettingsButtonClicked()
    {
        optionsPanel.SetActive(false);
        settingsPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(senseSlider);
    }

    public void CloseSettingsButtonClicked()
    {
        optionsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }

    public void TransactionFailed()
    {
        transactionText.text = "Transaction Failed";
        transactionButton.SetActive(true);
        //transactionButtonText.text = ""
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(transactionButton);
    }

    public void TransactionConfirmed()
    {
        transactionText.text = "Transaction Confirmed";
        transactionButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(transactionButton);
    }

    public void TransactionButton_clicked()
    {
        //Debug.Log("Back Clicked");
        GameManager.instance.UpdateGameState(GameState.MainMenu);
        StartCoroutine(LoadSceneAsync(0));
    }

    public void GameOverNormalButton_clicked()
    {
        gameOverPanel.SetActive(false);
        transactionPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(gameOverFreeButton);
    }

    public void BackToMenuButton_clicked()
    {
        GameManager.instance.UpdateGameState(GameState.MainMenu);
        StartCoroutine(LoadSceneAsync(0));
    }

    public void ConfirmQuitGame_clicked()
    {
        //throw new NotImplementedException();

        GameManager.instance.UpdateGameState(GameState.GameOver);

        if (GameManager.instance.isFreeMode)
        {
            //GameManager.instance.UpdateGameState(GameState.GameOver);
            /*GameManager.instance.UpdateGameState(GameState.MainMenu);
            StartCoroutine(LoadSceneAsync(0));*/
        }
    }

    public void QuitGame_clicked()
    {
        quitPanel.SetActive(true);
        pausePanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(cancelQuitButton);
    }

    public void KeepPlaying_clicked()
    {
        quitPanel.SetActive(false);
        pausePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeGameButton);
    }

    public void ResumeGame_clicked()
    {
        GameEvents.instance.ResumeGame();
    }
    

    public void ResumeGame()
    {
        //pauseOverlay.visible = false;
        pausePanel.SetActive(false);
        quitPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        
    }

    public void PauseGame()
    {
        //pauseOverlay.visible = true;
        if(GameManager.instance.State == GameState.Playing || GameManager.instance.State == GameState.BossFight || GameManager.instance.State == GameState.BonusRound)
        {
            pausePanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeGameButton);
        }
    }

    public void MatchEnd()
    {
        pausePanel.SetActive(false);
        quitPanel.SetActive(false);
        gameOverlay.SetActive(false);
        gameOverPanel.SetActive(true);

        if(GameManager.instance.GetPot() == 0 || GameManager.instance.isFreeMode)
        {
            gameOverFreeButton.SetActive(true);
            gameOverButton.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(gameOverFreeButton);
        }

        else if (GameManager.instance.GetPot() == 0 && !GameManager.instance.isFreeMode)
        {
            gameOverFreeButton.SetActive(false);
            gameOverButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(gameOverButton);
        }

        else
        {
            finalPotText.text = GameManager.instance.GetPot().ToString();
            gameOverFreeButton.SetActive(false);
            gameOverButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(gameOverButton);
        }

    }

    public void BossFightStart()
    {
        matchOverlay.SetActive(false);
        bossOverlay.SetActive(true);
    }

    public void UpdateBossLifeBar(float life)
    {
        //bossLifeBarProgress.style.width = Length.Percent(life);
        bossLifeBar.value = life;
    }

    public void MatchStart()
    {
        introScreen.SetActive(true);
    }

    public void WaveStart()
    {
        levelCounter.text = WavesManager.instance.GetLevel().ToString() + "-" + WavesManager.instance.GetWave().ToString();
        introScreen.SetActive(false);
        StartCoroutine(NewWavePopUp(levelCounter.text));
    }

    public void BonusStart()
    {
        levelCounter.text = "BONUS x" + WavesManager.instance.GetMultiplier().ToString();
        StartCoroutine(NewWavePopUp(levelCounter.text));
    }

    public void TakeDamage()
    {
        lifeCounter[thisPlayer.life - 1].SetActive(false);
    }

    public void UpdadeScore()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
        Sequence scoreFX = DOTween.Sequence();
        scoreFX.Append(scoreTextObject.transform.DOScale(1.1f, 0.15f));
        scoreFX.Append(scoreTextObject.transform.DOScale(1, 0.20f));

    }

    public void UpdadePot()
    {
        potText.text = GameManager.instance.GetPot().ToString();
    }

    public void OnDestroy()
    {
        GameEvents.instance.onTakeDamage -= TakeDamage;
        GameEvents.instance.onUpdateScore -= UpdadeScore;
        GameEvents.instance.onCountDown -= CountDown;
        GameEvents.instance.onMatchStart -= MatchStart;
    }

    public void CountDown()
    {
        int number;
        var timer = countdownText;
        bool success = int.TryParse(timer.text, out number);
        if(success)
        {
            number--;
            countdownText.text = number.ToString();
            if (number <= 0)
                countdownText.text = "Go!";
        }

    }

    IEnumerator LoadSceneAsync(int sceneNumber)
    {
        AsyncOperation isLoaded = SceneManager.LoadSceneAsync(sceneNumber);

        while (!isLoaded.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene Loaded");
    }

    IEnumerator NewWavePopUp(string newWave)
    {
        newWaveText.text = newWave;
        newWavePanel.SetActive(true);
        float timer = 3;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }
        
        newWavePanel.SetActive(false);
    }
}
