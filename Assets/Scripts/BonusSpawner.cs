using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Vector2 spawnInterval;
    [SerializeField] private bool isBonusRound;

    public static BonusSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameEvents.instance.onMatchStart += MatchStart;
        GameEvents.instance.onBonusStart += BonusStart;
        GameEvents.instance.onBonusEnd += BonusEnd;
    }

    private void BonusStart()
    {
        if (GameManager.instance.State != GameState.BonusRound)
            return;

        isBonusRound = true;
        StartCoroutine(SpawnCicle());
    }

    private void BonusEnd()
    {
        isBonusRound = false;
    }

    private void MatchStart()
    {

    }

    IEnumerator SpawnCicle()
    {
        while(isBonusRound)
        {
            Vector3 newPos = new Vector3(GetRandomX, GetRandomY, transform.position.z);
            //Instantiate(prefabs[Random.Range(0, prefabs.Length)], newPos, transform.rotation);

            float waitRandom = Random.Range(spawnInterval.x, spawnInterval.y);
            yield return new WaitForSeconds(waitRandom);
        }
    }

    private float GetRandomX
    {
        get => Random.Range(-4f, 4f);
    }

    private float GetRandomY
    {
        get => Random.Range(-3f, 3f);
    }
}
