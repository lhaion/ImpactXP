using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [GradientUsage(true)] public Gradient[] tunelColor;
    [GradientUsage(true)] public Gradient[] nebulaColor;
    //public Color[] normalColor;
    public float[] displacementAmount;
    [SerializeField] private Vector2 spawnInterval;
    [SerializeField] private bool isRoundEnded = false;

    [SerializeField] private VisualEffect effect;
    [SerializeField] private VisualEffect[] nebulas;

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
        effect.SetGradient("Gradient", tunelColor[WavesManager.instance.GetLevel()]);
        nebulas[0].SetGradient("Color", nebulaColor[WavesManager.instance.GetLevel()]);
        nebulas[1].SetGradient("Color", nebulaColor[WavesManager.instance.GetLevel()]);
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

        int level = WavesManager.instance.GetLevel();

        while(!isRoundEnded)
        {
            Vector3 newPos = new Vector3(GetRandomX, GetRandomY, transform.position.z);
            
            if(level < 5)
            {
                var newEnemy = Instantiate(prefabs[level - 1], newPos, transform.rotation);
            }
            else
            {
                var newEnemy = Instantiate(prefabs[Mathf.FloorToInt(Random.Range(0, 4))], newPos, transform.rotation);
            }
            
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
