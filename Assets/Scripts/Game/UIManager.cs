using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private Label scoreText;
    private Label potText;
    private Label levelCounter;
    private Label countdownLabel;

    private VisualElement lifeCounter;
    private VisualElement introScreen;
    private VisualElement levelElement;
    private VisualElement bossOverlay;
    private VisualElement gameOverlay;
    private VisualElement pauseOverlay;
    private VisualElement gameOverOverlay;
    private VisualElement bossLifeBarProgress;
    private VisualElement settingsOverlay;

    private Button resumeGameButton;
    private Button quitGameButton;

    private PlayerManager thisPlayer;


    void Awake()
    {
        thisPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        var root = GetComponent<UIDocument>().rootVisualElement;

        scoreText = root.Q<Label>("Score");
        potText = root.Q<Label>("potScore-label");
        countdownLabel = root.Q<Label>("Countdown");
        levelCounter = root.Q<Label>("levelCounter-label");

        lifeCounter = root.Q<VisualElement>("LifeCounter");
        introScreen = root.Q<VisualElement>("IntroOverlay");
        levelElement = root.Q<VisualElement>("level-element");
        bossOverlay = root.Q<VisualElement>("BossOverlay");
        gameOverOverlay = root.Q<VisualElement>("GameOverOverlay");
        gameOverlay = root.Q<VisualElement>("GameOverlay");
        pauseOverlay = root.Q<VisualElement>("PauseOverlay");
        settingsOverlay = root.Q<VisualElement>("SettingsOverlay");
        bossLifeBarProgress = root.Q<VisualElement>("progress");

        resumeGameButton = root.Q<Button>("resumegame-button");
        quitGameButton = root.Q<Button>("pausetomenu-button");
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

        resumeGameButton.clicked += ResumeGame_clicked;
        quitGameButton.clicked += QuitGame_clicked;

        introScreen.visible = true;
    }

    private void QuitGame_clicked()
    {
        //throw new NotImplementedException();
        GameEvents.instance.MatchEnd();

    }

    private void ResumeGame_clicked()
    {
        GameEvents.instance.ResumeGame();
    }

    private void ResumeGame()
    {
        pauseOverlay.visible = false;
    }

    private void PauseGame()
    {
        pauseOverlay.visible = true;
    }

    private void MatchEnd()
    {
        pauseOverlay.visible = false;
        gameOverlay.visible = false;
        gameOverOverlay.visible = true;
    }

    private void BossFightStart()
    {
        levelElement.visible = false;
        bossOverlay.visible = true;
    }

    public void UpdateBossLifeBar(float life)
    {
        bossLifeBarProgress.style.width = Length.Percent(life);
    }

    private void MatchStart()
    {
        introScreen.visible = false;
    }

    private void WaveStart()
    {
        levelCounter.text = WavesManager.instance.GetLevel().ToString() + "-" + WavesManager.instance.GetWave().ToString();
    }

    private void BonusStart()
    {
        levelCounter.text = "BONUS x" + WavesManager.instance.GetMultiplier().ToString();
    }

    private void TakeDamage()
    {
        lifeCounter.RemoveAt(Mathf.Clamp(thisPlayer.life - 1, 0, 100));
    }

    private void UpdadeScore()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
    }

    private void UpdadePot()
    {
        potText.text = GameManager.instance.GetPot().ToString();
    }

    private void OnDestroy()
    {
        GameEvents.instance.onTakeDamage -= TakeDamage;
        GameEvents.instance.onUpdateScore -= UpdadeScore;
        GameEvents.instance.onCountDown -= CountDown;
        GameEvents.instance.onMatchStart -= MatchStart;
    }

    private void CountDown()
    {
        int number;
        var timer = countdownLabel.text;
        bool success = int.TryParse(timer, out number);
        if(success)
        {
            number--;
            countdownLabel.text = number.ToString();
            if (number <= 0)
                countdownLabel.text = "Go!";
        }
        else
        {
            //print("deu ruim");
        }
        

    }
}
