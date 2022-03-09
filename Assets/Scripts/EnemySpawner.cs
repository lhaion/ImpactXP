using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [ColorUsage(true, true)] public Color[] fresnelColor;
    public Color[] normalColor;
    public float[] displacementAmount;
    [SerializeField] private Vector2 spawnInterval;
    [SerializeField] private bool isRoundEnded = false;

    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameEvents.instance.onMatchStart += MatchStart;
        //GameEvents.instance.onWaveStart += WaveStart;
        GameEvents.instance.onRoundStart += RoundStart;
        GameEvents.instance.onRoundEnd += RoundEnd;
    }

    private void RoundEnd()
    {
        isRoundEnded = true;
    }

    private void RoundStart()
    {
        isRoundEnded = false;
        
        WaveStart();
    }

    private void WaveStart()
    {
        StartCoroutine(SpawnCycle());
    }

    private void MatchStart()
    {
        WaveStart();
    }

    private IEnumerator SpawnCycle()
    {
        GameEvents.instance.WaveStart();

        int level = WavesManager.instance.GetLevel() - 1;

        while(!isRoundEnded)
        {
            Vector3 newPos = new Vector3(GetRandomX, GetRandomY, transform.position.z);
            
            Instantiate(prefabs[level], newPos, transform.rotation);
            //newEnemy.gameObject.GetComponent<EnemyBehaviour>().SetSpawnStats(fresnelColor[level], normalColor[level], displacementAmount[level]);

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
