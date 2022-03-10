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
    [SerializeField] private AudioSource audioSource;
    private float shootTimeStamp = 0;
    [SerializeField] private Transform target;
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(shotOrigin.position, (target.position - shotOrigin.position), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(shotOrigin.position, (target.position - shotOrigin.position) * hit.distance, Color.yellow);
            Debug.Log(hit.collider);
            if(hit.collider.tag == "Enemy")
            {

            }
        }
        else
        {
            Debug.DrawRay(shotOrigin.position, (target.position - shotOrigin.position) * 1000, Color.white);

            //Debug.Log("Did not Hit");
        }

        DrawLine(shotOrigin.position, target.position);

    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
    void Shoot()
    {
        Vector3 lookAtPos = target.position - shotOrigin.position;
        Quaternion newRotation = Quaternion.LookRotation(lookAtPos, Vector3.up);

        var newShot = Instantiate(shotPrefab, shotOrigin.position, newRotation);
        newShot.GetComponent<Rigidbody>().velocity = newShot.transform.forward * shotSpeed;
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
        if(Time.time >= shootTimeStamp && this.enabled)
        {
            Shoot();
            shootTimeStamp = Time.time + fireRateInterval;
        }
        
    }
}
