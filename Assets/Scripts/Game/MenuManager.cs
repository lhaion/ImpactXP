using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject walletMenu;
    public GameObject newGameMenu;
    public GameObject settingsMenu;

    public GameObject WPconnectingWalletPanel;
    public GameObject WPconnectWalletPanel;
    public GameObject WPwalletErrorButtons;
    public TMPro.TMP_Text WPwalletErrorText;

    public GameObject MMconnectedWalletPanel;
    public GameObject MMconnectWalletPanel;


    public TMPro.TMP_Text coins;
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
        WPconnectWalletPanel.SetActive(true);
        WPconnectingWalletPanel.SetActive(false);
        MMconnectedWalletPanel.SetActive(true);
        MMconnectWalletPanel.SetActive(false);
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
    }

    public void CloseSettings()
    {
        buttonsPanel.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void NewGameButton_clicked()
    {
        buttonsPanel.SetActive(false);
        newGameMenu.SetActive(true);
    }

    public void WalletButton_clicked()
    {
        walletMenu.SetActive(true);
        WPconnectWalletPanel.SetActive(true);
        WPconnectingWalletPanel.SetActive(false);
    }





    public void CloseWalletButton_clicked()
    {
        walletMenu.SetActive(false);
    }

    public void ClosePopUpButton_clicked()
    {
        noCoinsPopUp.SetActive(true);
    }

    public void SettingsButton_clicked()
    {
        buttonsPanel.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitGameButton_clicked()
    {
        //throw new System.NotImplementedException();
        Application.Quit();
    }

    public void StartGameButton_clicked()
    {
        if (GameManager.instance.GetCoins() <= 0)
        {
            NoCoins();
        }
        else
        {
            GameManager.instance.AddCoins(-1);
            coins.text = "Coins: " + GameManager.instance.GetCoins().ToString();
            StartCoroutine(LoadSceneAsync(1));
        }

    }

    public void StartGameButtonx2_clicked()
    {
        StartCoroutine(LoadSceneAsync(2));
    }

    public void NoCoins()
    {
        noCoinsPopUp.SetActive(true);
    }

    IEnumerator LoadSceneAsync(int sceneNumber)
    {
        AsyncOperation isLoaded = SceneManager.LoadSceneAsync(sceneNumber);

        while(!isLoaded.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene Loaded");
    }
}
