using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float score { get; private set; }
    [SerializeField]public int life { get; [SerializeField]private set; } = 3;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onTakeDamage += TakeDamage;
    }

    private void TakeDamage()
    {
        life--;

        if(life <= 0)
        {
            GameManager.instance.UpdateGameState(GameState.GameOver);
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameEvents.instance.onTakeDamage -= TakeDamage;
    }

}