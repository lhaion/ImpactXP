using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform shotOrigin;
    [SerializeField] private GameObject shotPrefab;
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
        var newShot = Instantiate(shotPrefab, shotOrigin.position, Quaternion.identity);
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
