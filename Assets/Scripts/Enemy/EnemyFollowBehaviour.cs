using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyFollowBehaviour : MonoBehaviour
{
    public Transform target;
    //public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] float followTimer = 3;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        StartCoroutine(FollowTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && followTimer > 0 && transform.position.z > 4f)
        {
            Follow();
        }
    }

    private IEnumerator FollowTimer()
    {
        while(followTimer > 0)
        {
            followTimer--;
            //Debug.Log(followTimer);
            yield return new WaitForSeconds(1f);
        }
    }

    public void Follow()
    {
        transform.LookAt(target, transform.forward);
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }
}
