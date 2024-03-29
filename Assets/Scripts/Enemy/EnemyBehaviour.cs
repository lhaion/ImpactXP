using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20f;
    [SerializeField] private float m_RotationSpeed = 180f;
    [SerializeField] private GameObject m_VisualEffectObject;
    [SerializeField] private float value = 10;
    [SerializeField] private bool isRandom = true;

    [SerializeField] private Renderer[] objectRenderers;
    [SerializeField] private Mesh[] mesh;
    [SerializeField] private MeshFilter meshFilter;
    /*[ColorUsage(true, true)]public Color emissiveColor;
    public Color color;
    public float displacementAmount = 0.05f;*/

    void Start()
    {
        //objectRenderer = GetComponent<Renderer>();
        //SetSpawnStats();

        if(isRandom)
        {
            meshFilter = GetComponent<MeshFilter>();
            meshFilter.mesh = mesh[Mathf.FloorToInt(Random.Range(0, mesh.Length))];
        }

        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 1);
        
        Destroy(gameObject, 10f);

    }

    public void SetSpawnStats()
    {
        int level = WavesManager.instance.GetLevel() - 1;

        foreach (Renderer objectRenderer in objectRenderers)
        {
            /*objectRenderer.material.SetColor("_FresnelColor", EnemySpawner.instance.fresnelColor[level]);
            objectRenderer.material.SetColor("_Color", EnemySpawner.instance.normalColor[level]);
            objectRenderer.material.SetFloat("_DisplacementAmount", EnemySpawner.instance.displacementAmount[level]);*/
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.forward * -m_Speed * Time.deltaTime);
        transform.Translate(0, 0, m_Speed * Time.deltaTime);
        transform.Rotate(0, 0, Time.deltaTime * m_RotationSpeed);
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log($"Triggered by {col.gameObject}");
        
        if(col.gameObject.CompareTag("Bullet"))
        {
            GameEvents.instance.EnemyDestroyed();
            GameManager.instance.AddScore(value);
            
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 4f);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if(col.gameObject.CompareTag("Player"))
        {
            GameEvents.instance.EnemyDestroyed();
            GameEvents.instance.TakeDamage();
            
            var explosion = Instantiate(m_VisualEffectObject, col.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        /*var explosion = Instantiate(m_VisualEffectObject, transform.position, Quaternion.identity);
        Destroy(explosion, 4f);
        Destroy(this.gameObject);*/
    }
}
