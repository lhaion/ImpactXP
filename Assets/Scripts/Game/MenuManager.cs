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

    public GameObject leaderboardPanel;

    public GameObject walletMenu;
    public GameObject newGameMenu;
    public GameObject settingsMenu;

    public GameObject normalGameButton;
    public GameObject newGameButton;
    public GameObject connectButton;
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
        /*var root = GetComponent<UIDocument>().rootVisualElement;

        startGameButton = root.Q<Button>("start-button");
        startGamex2Button = root.Q<Button>("startx2-button");
        quitGameButton = root.Q<Button>("quit-button");
        settingsButton = root.Q<Button>("settings-button");
        walletButton = root.Q<Button>("wallet-button");
        closePopUpButton = root.Q<Button>("closePopUp-button");
        closeWalletButton = root.Q<Button>("closeWallet-button");

        noCoinsPopUp = root.Q<VisualElement>("NoCoinsPopUp");
        walletMenu = root.Q<VisualElement>("WalletMenu");

        startGameButton.clicked += StartGameButton_clicked;
        quitGameButton.clicked += QuitGameButton_clicked;
        settingsButton.clicked += SettingsButton_clicked;
        startGamex2Button.clicked += StartGameButtonx2_clicked;
        closePopUpButton.clicked += ClosePopUpButton_clicked;
        closeWalletButton.clicked += CloseWalletButton_clicked;
        walletButton.clicked += WalletButton_clicked;

        coins = root.Q<Label>("coins");

        coins.text = "Coins: " + GameManager.instance.GetCoins().ToString();*/

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

    public void LeaderboardButton_clicked()
    {
        buttonsPanel.SetActive(false);
        leaderboardPanel.SetActive(true);

        StartCoroutine(GetTopScores());
    }

    IEnumerator GetTopScores()
    {
        const string getScoreUrl = "https://us-central1-impactxp-dac50.cloudfunctions.net/getTopScores";
        //const string getScoreUrl = "http://127.0.0.1:5001/impactxp-dac50/us-central1/getTopScores";


        var uwr = new UnityWebRequest(getScoreUrl, "Get");
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return uwr.SendWebRequest();
    }



}
