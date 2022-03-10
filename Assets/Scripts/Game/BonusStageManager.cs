using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class BonusStageManager : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void Start()
    {
        GameEvents.instance.onBossFightStart += BossFightStart;
    }

    private void BossFightStart()
    {
        boss.SetActive(true);
    }
}
