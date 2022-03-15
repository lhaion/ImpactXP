using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class BonusStageManager : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    

    private void Start()
    {
        GameEvents.instance.onBossFightStart += BossFightStart;

        GameManager.instance.UpdateGameState(GameState.Intro);
        StartCoroutine(Countdown());
    }

    private void BossFightStart()
    {
        boss.SetActive(true);
    }

    IEnumerator Countdown()
    {
        int count = 4;
        while (count > 0)
        {
            yield return new WaitForSeconds(1f);
            count--;
            GameEvents.instance.CountDown();
        }

        GameManager.instance.UpdateGameState(GameState.Playing);
    }

}
