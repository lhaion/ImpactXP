using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private Label scoreText;
    private Label potText;
    private VisualElement lifeCounter;
    private Label levelCounter;
    private VisualElement introScreen;
    private Label countdownLabel;
    private PlayerManager thisPlayer;

    void Awake()
    {
        thisPlayer = GetComponent<PlayerManager>();
        var root = GetComponent<UIDocument>().rootVisualElement;

        scoreText = root.Q<Label>("Score");
        potText = root.Q<Label>("potScore-label");
        countdownLabel = root.Q<Label>("Countdown");
        levelCounter = root.Q<Label>("levelCounter-label");
        lifeCounter = root.Q<VisualElement>("LifeCounter");
        introScreen = root.Q<VisualElement>("IntroOverlay");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onTakeDamage += TakeDamage;
        GameEvents.instance.onUpdateScore += UpdadeScore;
        GameEvents.instance.onUpdatePot += UpdadePot;
        GameEvents.instance.onCountDown += CountDown;
        GameEvents.instance.onMatchStart += MatchStart;
        GameEvents.instance.onWaveStart += WaveStart;
        GameEvents.instance.onBonusStart += BonusStart;

        introScreen.visible = true;
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
        lifeCounter.RemoveAt(thisPlayer.life - 1);
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
