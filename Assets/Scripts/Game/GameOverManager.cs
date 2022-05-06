using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;


public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private bool isGameOver;

    /*[SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private float velocity = 0.0f;
    [SerializeField] private float gameTimeScale = 1;*/

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onMatchEnd += GameOver;
    }

    private void Update()
    {

    }

    private void GameOver()
    {
        SaveScore();

        //spawnManager.SetActive(false);
        //Time.timeScale = 0;
        isGameOver = true;
        spawnManager.SetActive(false);
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void SaveScore()
    {
        float score = GameManager.instance.GetPot();

        GameScore gameScore = new GameScore();

        gameScore.Score = score;

        // wallet?

        StartCoroutine(SendScore(gameScore));
    }

    IEnumerator SendScore(GameScore score)
    {
        //const string sendScoreUrl = "https://us-central1-impactxp-dac50.cloudfunctions.net/newScore";
        const string sendScoreUrl = "http://127.0.0.1:5001/impactxp-dac50/us-central1/newScore";

        string json = JsonConvert.SerializeObject(score);

        var uwr = new UnityWebRequest(sendScoreUrl, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();
    }


}