using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExplosionManager : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20f;
    [SerializeField] private GameObject m_VisualEffectObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, m_Speed * Time.deltaTime);
    }

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
