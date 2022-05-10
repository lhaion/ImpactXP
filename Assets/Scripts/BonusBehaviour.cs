using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    
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
            Destroy(this.gameObject);
        }
    }
}
