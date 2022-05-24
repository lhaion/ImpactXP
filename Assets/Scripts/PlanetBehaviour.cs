using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);

        transform.DOScale(new Vector3(1, 1, 1), 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
