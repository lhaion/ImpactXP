using UnityEngine;
using UnityEngine.Audio;

public class GameAudioEvents : MonoBehaviour
{
    [SerializeField] private AudioSource enemyAudio, bonusAudio;

    [SerializeField] private AudioClip[] enemyClips, bonusClips;

    private void Start()
    {
        GameEvents.instance.onEnemyDestroyed += PlayEnemyDestroyed;
        GameEvents.instance.onCubeDestroyed += PlayCubeDestroyed;
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
}
