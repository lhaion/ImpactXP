using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject aim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        aim.transform.position = new Vector3 (0, 0, aim.transform.position.z);

        GameEvents.instance.onMatchEnd += GameOver;
        GameEvents.instance.onPauseGame += PauseGame;
        GameEvents.instance.onResumeGame += ResumeGame;
    }

    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void OnPause()
    {
        if(GameManager.instance.State == GameState.Playing)
        {
            if (!GameManager.instance.isPaused)
                GameEvents.instance.PauseGame();
            else
                GameEvents.instance.ResumeGame();
        }
    }

    public void PauseGame()
    {
        GameManager.instance.isPaused = true;

        Cursor.lockState = CursorLockMode.Confined;

        if (GameManager.instance.isPaused)
        {
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        GameManager.instance.isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;

        if (!GameManager.instance.isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
