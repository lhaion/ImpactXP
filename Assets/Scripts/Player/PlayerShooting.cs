using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform shotOrigin;
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private AudioClip[] shotAudioClip;
    [SerializeField] private float shotSpeed = 10;
    [SerializeField] private float fireRateInterval = 0.3f;
    private AudioSource audioSource;
    private float shootTimeStamp = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(shotOrigin.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(shotOrigin.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log(hit.collider);
        }
        else
        {
            Debug.DrawRay(shotOrigin.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
    void Shoot()
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

    public void OnFire()
    {
        //Debug.Log("Shoot");
        if(Time.time >= shootTimeStamp)
        {
            Shoot();
            shootTimeStamp = Time.time + fireRateInterval;
        }
        
    }
}
