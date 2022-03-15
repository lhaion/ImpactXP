using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Vector2 spawnInterval;
    [SerializeField] private bool isBonusRound;
    [SerializeField] private float shotSpeed = 35;
    [SerializeField] private float bonusValue;

    public static BonusSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameEvents.instance.onBonusStart += BonusStart;
        GameEvents.instance.onBonusEnd += BonusEnd;
    }

    private void BonusStart()
    {
        if (GameManager.instance.State != GameState.BonusRound)
            return;

        isBonusRound = true;
        bonusValue = (GameManager.instance.GetScore() * WavesManager.instance.GetMultiplier()) - GameManager.instance.GetScore();
        StartCoroutine(SpawnCicle());
    }

    private void BonusEnd()
    {
        isBonusRound = false;
    }

    IEnumerator SpawnCicle()
    {
        while(isBonusRound)
        {
            Vector3 newPos = new Vector3(GetRandomX, GetRandomY, transform.position.z);
            var newBonus = Instantiate(prefabs[Random.Range(0, prefabs.Length)], newPos, transform.rotation);
            newBonus.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
            newBonus.GetComponent<BonusBehaviour>().SetValue(bonusValue);
            float waitRandom = Random.Range(spawnInterval.x, spawnInterval.y);
            yield return new WaitForSeconds(waitRandom);
        }
    }

    private float GetRandomX
    {
        get => Random.Range(-8f, 8f);
    }

    private float GetRandomY
    {
        get => Random.Range(-8f, 8f);
    }
}
