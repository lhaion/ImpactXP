using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{

    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private Transform[] shotOrigin;
    [SerializeField] private AudioClip[] shotAudioClip;
    [SerializeField] private float shotSpeed = 10;
    [SerializeField] private float shootInterval = 1;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Shoot", 1f, shootInterval);
    }

    private void Shoot()
    {
        int choosenHead = Mathf.FloorToInt(Random.Range(0, shotOrigin.Length));
        Vector3 headPosition = shotOrigin[choosenHead].position;

        var newShot = Instantiate(shotPrefab, headPosition, shotOrigin[choosenHead].rotation);
        newShot.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;

        Destroy(newShot, 4f);

        ManageAudio();
    }

    void ManageAudio()
    {
        int randomClip = Mathf.FloorToInt(Random.Range(0, shotAudioClip.Length));
        audioSource.PlayOneShot(shotAudioClip[randomClip]);
    }
}
