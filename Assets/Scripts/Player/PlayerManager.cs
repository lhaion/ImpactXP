using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float score { get; private set; }
    [SerializeField] public int life { get; [SerializeField] private set; } = 3;
    public Volume volume;
    public Vignette vignette;
    private Sequence newSequence;

    [SerializeField] private float redTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onTakeDamage += TakeDamage;
        GameEvents.instance.onMatchStart += MatchStart;

        volume.profile.TryGet<Vignette>(out vignette);
        

    }

    private void MatchStart()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerShooting>().enabled = true;
    }

    private void TakeDamage()
    {
        life--;

        ShakeCamera.instance.Shake(1, 1);

        newSequence = DOTween.Sequence();
        newSequence.Append(DOTween.To(RedScreen, 0, 0.7f, 0.3f));
        newSequence.Append(DOTween.To(RedScreen, 0.7f, 0, 0.3f));

        if (life <= 0)
        {
            GameManager.instance.UpdateGameState(GameState.GameOver);
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {

    }

    private void OnDestroy()
    {
        GameEvents.instance.onTakeDamage -= TakeDamage;
    }

    void RedScreen(float intensity)
    {
        vignette.intensity.value = intensity;
        Time.timeScale = 1 - intensity;
        Gamepad.current.SetMotorSpeeds(intensity, intensity);
    }
}
