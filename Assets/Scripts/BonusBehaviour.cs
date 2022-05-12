using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private float value;
    public void SetValue(float newValue)
    {
        value = newValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddScore(value);
            GameEvents.instance.CubeDestroyed();
            var newExplosion = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(newExplosion, 2f);
            Destroy(this.gameObject);
        }
    }
}
