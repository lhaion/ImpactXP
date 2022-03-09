using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject m_VisualEffectObject;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            GameEvents.instance.TakeDamage();
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(this.gameObject);
        }
    }
}
