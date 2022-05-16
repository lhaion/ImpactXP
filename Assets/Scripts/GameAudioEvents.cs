using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class GameAudioEvents : MonoBehaviour
{
    [SerializeField] private AudioSource enemyAudio, bonusAudio;
    [SerializeField] private AudioSource[] soundtracks;
    [SerializeField] private AudioClip[] enemyClips, bonusClips;

    [SerializeField] private float timeToFade = 1f;

    private void Start()
    {
        GameEvents.instance.onEnemyDestroyed += PlayEnemyDestroyed;
        GameEvents.instance.onCubeDestroyed += PlayCubeDestroyed;
        GameEvents.instance.onBossFightStart += StartFade;
    }

    private void StartFade()
    {
        StartCoroutine(FadeTracks(soundtracks[0], soundtracks[1]));
    }

    private void PlayCubeDestroyed()
    {
        //bonusAudio.Play();
        int randomClip = Mathf.FloorToInt(Random.Range(0, bonusClips.Length));
        bonusAudio.PlayOneShot(bonusClips[randomClip]);
    }

    private void PlayEnemyDestroyed()
    {
        //enemyAudio.Play();
        int randomClip = Mathf.FloorToInt(Random.Range(0, enemyClips.Length));
        enemyAudio.PlayOneShot(enemyClips[randomClip]);
    }

    private void OnDestroy()
    {
        GameEvents.instance.onEnemyDestroyed -= PlayEnemyDestroyed;
        GameEvents.instance.onCubeDestroyed -= PlayCubeDestroyed;
    }
    
    

    public IEnumerator FadeTracks(AudioSource from, AudioSource to)
    {
        float timeElapsed = 0;
        
        to.Play();

        while (timeElapsed < timeToFade)
        {
            from.volume = Mathf.Lerp(0.5f, 0f, timeElapsed / timeToFade);
            to.volume = Mathf.Lerp(0f, 0.5f, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        
        from.Stop();
    }
}
