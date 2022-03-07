using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private Label scoreText;
    private VisualElement lifeCounter;
    private VisualElement introScreen;
    private Label countdownLabel;
    private PlayerManager thisPlayer;

    void Awake()
    {
        thisPlayer = GetComponent<PlayerManager>();
        var root = GetComponent<UIDocument>().rootVisualElement;

        scoreText = root.Q<Label>("Score");
        countdownLabel = root.Q<Label>("Countdown");
        lifeCounter = root.Q<VisualElement>("LifeCounter");
        introScreen = root.Q<VisualElement>("IntroOverlay");
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onTakeDamage += TakeDamage;
        GameEvents.instance.onUpdateScore += UpdadeScore;
        GameEvents.instance.onCountDown += CountDown;
        GameEvents.instance.onMatchStart += MatchStart;

        introScreen.visible = true;
    }

    private void MatchStart()
    {
        introScreen.visible = false;
    }

    private void TakeDamage()
    {
        lifeCounter.RemoveAt(thisPlayer.life - 1);
    }

    private void UpdadeScore()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
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
            print("deu ruim");
        }
        

    }
}
