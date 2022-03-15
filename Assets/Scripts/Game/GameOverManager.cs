using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //spawnManager.SetActive(false);
        //Time.timeScale = 0;
        isGameOver = true;
        spawnManager.SetActive(false);
        //Cursor.lockState = CursorLockMode.Confined;
    }
}
