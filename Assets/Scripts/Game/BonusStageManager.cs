using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class BonusStageManager : MonoBehaviour {
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Vector2 spawnInterval;

    public static BonusStageManager instance;

    private float GetRandomX {
        get => Random.Range(-4f, 4f);
    }

    private float GetRandomY {
        get => Random.Range(-3f, 3f);
    }

    private IEnumerator Start() {
        Vector3 newPos = new Vector3(GetRandomX, GetRandomY, transform.position.z);
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], newPos, transform.rotation);

        float waitRandom = Random.Range(spawnInterval.x, spawnInterval.y);
        yield return new WaitForSeconds(waitRandom);
        StartCoroutine("Start");
    }



    

}
