using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float life = 100;
    [SerializeField] private float damageTaken = 1;
    [SerializeField] private GameObject m_VisualEffectObject;
    [SerializeField] private GameObject m_SceneManager;
    [SerializeField] private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_SceneManager = GameObject.FindGameObjectWithTag("Scene Manager");
        m_SceneManager.GetComponent<UIManager>().UpdateBossLifeBar(life);

        //GameEvents.instance.onBossFightEnd += BossFightEnd;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && life > 0)
        {
            life = Mathf.Clamp(life - damageTaken, 0, 100);

            m_SceneManager.GetComponent<UIManager>().UpdateBossLifeBar(life);

            GameManager.instance.AddScore(10);
            var explosion = Instantiate(m_VisualEffectObject, other.transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(other.gameObject);

            if(life <= 0)
            {
                StartCoroutine(Dissolve(-30, 0.1f));
                GameEvents.instance.BossFightEnd();
            }
        }
    }

    private void OnEnable()
    {
        m_SceneManager = GameObject.FindGameObjectWithTag("Scene Manager");
        m_SceneManager.GetComponent<UIManager>().UpdateBossLifeBar(life);
        StartCoroutine(Dissolve(30, 0.025f));
    }

    IEnumerator Dissolve(float value, float time)
    {
        GetComponent<BossShooter>().enabled = false;

        float t = 0;

        while (t < 1.1f)
        {
            float height = Mathf.Lerp(-value, value, t);
            objectRenderer.material.SetFloat("_Cutoff_Height", height);
            t += 1f * Time.deltaTime;
            
            yield return new WaitForSeconds(time);
        }

        Debug.Log("Dissolved");

        if(life == 0)
        {
            GameManager.instance.UpdateGameState(GameState.GameOver);
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<BossShooter>().enabled = true;
        }

        

    }


}
