using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using FusedVR.Web3;


public class MenuManager : MonoBehaviour
{
    public Button startGameButton;
    public Button startGamex4Button;
    public Button quitGameButton;
    public Button settingsButton;
    public Button walletButton;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startGameButton = root.Q<Button>("start-button");
        startGamex4Button = root.Q<Button>("startx4-button");
        quitGameButton = root.Q<Button>("quit-button");
        settingsButton = root.Q<Button>("settings-button");
        walletButton = root.Q<Button>("wallet-button");

        startGameButton.clicked += StartGameButton_clicked;
        quitGameButton.clicked += QuitGameButton_clicked;
        settingsButton.clicked += SettingsButton_clicked;
        startGamex4Button.clicked += StartGameButtonx4_clicked;
    }

    private void SettingsButton_clicked()
    {
        throw new System.NotImplementedException();
    }

    private void QuitGameButton_clicked()
    {
        throw new System.NotImplementedException();
    }

    private void StartGameButton_clicked()
    {
        StartCoroutine(LoadSceneAsync(1));
    }

    private void StartGameButtonx4_clicked()
    {
        StartCoroutine(LoadSceneAsync(2));
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
