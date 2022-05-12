using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    public TMPro.TMP_Text finalPot;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onMatchEnd += UpdateFinalPot;
    }

    private void UpdateFinalPot()
    {
        finalPot.text = GameManager.instance.GetPot().ToString();
    }

    private void SettingsButton_clicked()
    {
        throw new System.NotImplementedException();
    }

    private void QuitGameButton_clicked()
    {
        Debug.Log("Back Clicked");
        GameManager.instance.UpdateGameState(GameState.MainMenu);
        StartCoroutine(LoadSceneAsync(0));
    }

    private void StartGameButton_clicked()
    {
        /*if (GameManager.instance.GetTokens() <= 0)
        {
            NoCoins();
        }
        else
        {
            
            StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
            GameManager.instance.AddCoins(-1);
        }*/
    }

    private void NoCoins()
    {

    }

    IEnumerator LoadSceneAsync(int sceneNumber)
    {
        AsyncOperation isLoaded = SceneManager.LoadSceneAsync(sceneNumber);

        while(!isLoaded.isDone)
        {
            yield return null;
        }

        //Debug.Log("Scene Loaded");

    }
}
