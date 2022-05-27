using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private float value;

    private void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }

    public void SetValue(float newValue)
    {
        value = newValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Bullet")) return;
        
        GameManager.instance.AddScore(value);
        GameEvents.instance.CubeDestroyed();
        var newExplosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);

        if (other.CompareTag("Bullet"))
            Destroy(other.gameObject);
        
        Destroy(newExplosion, 2f);
        Destroy(this.gameObject);
        
    }
}
