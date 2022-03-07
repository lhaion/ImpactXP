using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20f;
    [SerializeField] private float m_RotationSpeed = 180f;
    [SerializeField] private GameObject m_VisualEffectObject;
    [SerializeField] private float value = 10;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * -m_Speed * Time.deltaTime);
        transform.Rotate(transform.forward * Time.deltaTime * m_RotationSpeed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            GameManager.instance.AddScore(value);
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player")
        {
            GameEvents.instance.TakeDamage();
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(this.gameObject);
        }
    }
}
