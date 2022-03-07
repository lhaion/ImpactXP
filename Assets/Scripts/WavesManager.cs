using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField][Range(1, 5)] private int wavesCount = 1;
    [SerializeField][Range(1, 5)] private int level = 1;
    [SerializeField] private float levelTime;
    [SerializeField][Range(1, 1.20f)] private float bonusMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
