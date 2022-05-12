using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

using UnityEngine.Networking;
using Newtonsoft.Json;



public class MenuManager : MonoBehaviour
{
    /*public Button startGameButton;
    public Button startGamex2Button;
    public Button quitGameButton;
    public Button settingsButton;
    public Button walletButton;
    public Button closePopUpButton;
    public Button closeWalletButton;*/


    public GameObject noCoinsPopUp;

    public GameObject titlePanel;
    public GameObject walletPanel;
    public GameObject buttonsPanel;


    // Leaderboard stuff
    public GameObject leaderboardPanel;

    public GameObject scoreHolder;
    public GameObject leaderboardScoreUI;




    public GameObject walletMenu;
    public GameObject newGameMenu;
    public GameObject settingsMenu;

    public GameObject normalGameButton;
    public GameObject newGameButton;
    public GameObject connectButton;
    public GameObject noCoinsBackButton;
    public GameObject closeWalletConnectionButton;

    public GameObject senseSlider;

    public GameObject WPconnectingWalletPanel;
    public GameObject WPconnectWalletPanel;
    public GameObject WPwalletErrorButtons;
    public TMPro.TMP_Text WPwalletErrorText;

    public GameObject MMconnectedWalletPanel;
    public GameObject MMconnectWalletPanel;

    public TMPro.TMP_Text walletHash;
    public TMPro.TMP_Text tokensAmount;

    // Start is called before the first frame update
    void Start()
    {
        /*coins.text = "Coins: " + GameManager.instance.GetCoins().ToString();*/

        GameEvents.instance.onTryWalletConnection += Instance_onTryWalletConnection;
        GameEvents.instance.onWalletConnected += Instance_onWalletConnected;
        GameEvents.instance.onWalletError += Instance_onWalletError;
    }

    private void Instance_onWalletError()
    {
        WPwalletErrorButtons.SetActive(true);
        WPwalletErrorText.text = "CONNECTION FAILED";
    }

    private void Instance_onWalletConnected()
    {
        WPconnectWalletPanel.SetActive(false);
        WPconnectingWalletPanel.SetActive(false);
        MMconnectedWalletPanel.SetActive(true);
        walletMenu.SetActive(false);
        MMconnectWalletPanel.SetActive(false);
        walletHash.text = GameManager.instance.Wallet;
        tokensAmount.text = GameManager.instance.GetTokens().ToString();
    }

    private void Instance_onTryWalletConnection()
    {
        WPconnectWalletPanel.SetActive(false);
        WPconnectingWalletPanel.SetActive(true);
        WPwalletErrorText.text = "TRYING CONNECTION";

    }

    public void CloseNewGame()
    {
        buttonsPanel.SetActive(true);
        newGameMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }

    public void CloseSettings()
    {
        buttonsPanel.SetActive(true);
        settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }

    public void NewGameButton_clicked()
    {
        buttonsPanel.SetActive(false);
        newGameMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(normalGameButton);

    }

    public void WalletButton_clicked()
    {
        walletMenu.SetActive(true);
        WPconnectWalletPanel.SetActive(true);
        WPconnectingWalletPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeWalletConnectionButton);
    }

    public void CloseWalletButton_clicked()
    {
        walletMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }

    public void ClosePopUpButton_clicked()
    {
        noCoinsPopUp.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(normalGameButton);
    }

    public void SettingsButton_clicked()
    {
        buttonsPanel.SetActive(false);
        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(senseSlider);
    }

    public void QuitGameButton_clicked()
    {
        //throw new System.NotImplementedException();
        Application.Quit();
    }

    public void StartGameButton_clicked()
    {
        if (GameManager.instance.GetTokens() < GameManager.instance.GetTicketValue() || GameManager.instance.GetWalletState() == false)
        {
            NoCoins();
        }
        else
        {
            GameManager.instance.isFreeMode = false;
            GameManager.instance.AddTokens(-GameManager.instance.GetTicketValue());
            //coins.text = "Coins: " + GameManager.instance.GetCoins().ToString();
            StartCoroutine(LoadSceneAsync(1));
        }

    }

    public void StartGameButtonx2_clicked()
    {
        GameManager.instance.isFreeMode = true;
        StartCoroutine(LoadSceneAsync(2));
    }

    public void NoCoins()
    {
        noCoinsPopUp.SetActive(true);
        Debug.Log("No wallet or coins available");
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(noCoinsBackButton);
    }

    IEnumerator LoadSceneAsync(int sceneNumber)
    {
        AsyncOperation isLoaded = SceneManager.LoadSceneAsync(sceneNumber);

        while (!isLoaded.isDone)
        {
            yield return null;
        }

        //Debug.Log("Scene Loaded");
    }

    public void LeaderboardButton_clicked()
    {
        buttonsPanel.SetActive(false);
        leaderboardPanel.SetActive(true);


        clearLeaderboard();

        List<GameScore> scores = mockScores();

        for (int i = 0; i < scores.Count; i++)
        {
            GameScore score = scores[i];

            GameObject scoreUI = Instantiate(leaderboardScoreUI, scoreHolder.transform);
            scoreUI.GetComponent<LeaderboardScoreUI>().InitializeScoreUI(score.Wallet, score.Score.ToString());
            scoreUI.transform.position = new Vector3(scoreUI.transform.position.x, scoreUI.transform.position.y - (55 * i), scoreUI.transform.position.z);
        }
    }

    public void CloseLeaderboardButton_clicked()
    {
        leaderboardPanel.SetActive(false);
        buttonsPanel.SetActive(true);
    }

    public void clearLeaderboard()
    {
        foreach (Transform child in scoreHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    List<GameScore> mockScores()
    {
        List<GameScore> scores = new List<GameScore>();

        for (int i = 0; i < 10; i++)
        {
            scores.Add(new GameScore
            {
                Wallet = "KO354OK4T03G4-59I3-039F" + i,
                Score = i * 100
            });
        }

        return scores;
    }
}
