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
    [SerializeField] private Transform acquiredTarget;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject[] aims;
    private Camera mainCamera;
    public Vector3 screenPosition;
    public Vector3 desiredAimPosition;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        AcquireTarget();
    }

    void AcquireTarget()
    {
        screenPosition = mainCamera.WorldToScreenPoint(target.position);
        desiredAimPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, shotOrigin.position.z));
        CalculateTarget(desiredAimPosition);
    }

    void CalculateTarget(Vector3 aimPosition)
    {
        Vector3 direction = target.position - aimPosition;

        if (Physics.Raycast(desiredAimPosition, direction, out var hit, 300, 1 << 10))
        {
            //Debug.Log($"Did hit {hit.collider}");
            acquiredTarget = hit.collider.gameObject.transform;
            TargetRecoil(false);
        }
        else
        {
            TargetRecoil(true);
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
    void Shoot()
    {
        Vector3 position = shotOrigin.position;
        Quaternion newRotation = new Quaternion(0,0,0,0);
        if (acquiredTarget)
        {
            Vector3 lookAtPos = acquiredTarget.position - position;
            newRotation = Quaternion.LookRotation(lookAtPos, Vector3.up);
        }
        
        var newShot = Instantiate(shotPrefab, position, newRotation);
        newShot.GetComponent<Rigidbody>().velocity = newShot.transform.forward * shotSpeed;
        Destroy(newShot, 1.5f);
        ManageAudio();
    }

    void ManageAudio()
    {
        int randomClip = Mathf.FloorToInt(Random.Range(0, shotAudioClip.Length));
        audioSource.PlayOneShot(shotAudioClip[randomClip]);
    }

    public void OnFire()
    {
        if(Time.time >= shootTimeStamp && this.enabled && !GameManager.instance.isPaused)
        {
            Shoot();
            
            shootTimeStamp = Time.time + fireRateInterval;
        }
    }

    public void TargetRecoil(bool expand)
    {
        if (expand)
        {
            foreach (GameObject aim in aims)
            {
                aim.GetComponent<AimManager>().expand = true;
            }
        }
        else
        {
            foreach (GameObject aim in aims)
            {
                aim.GetComponent<AimManager>().expand = false;
            }
        }

    }
}
