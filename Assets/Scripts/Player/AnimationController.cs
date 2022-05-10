using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Animations;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public bool isPaused;
    public bool isTwirling;
    public GameObject playerMesh;
    public Transform target;
    private AnimatorClipInfo[] clipInfo;
    private float distanceX;
    private float distanceY;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(RandomPlay());

        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
    }

    private void FixedUpdate()
    {
        distanceX = target.position.x - transform.position.x;
        distanceY = target.position.y - transform.position.y;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("TL"))
        {
            isTwirling = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("TR"))
        {
            isTwirling = true;
        }
        else
        {
            isTwirling = false;
        }
        
        if(!isTwirling)
            HandleRotation();

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Twirl Right"));
    }

    IEnumerator RandomPlay()
    {
        while (!isPaused)
        {
            animator.SetTrigger("Fly");
            yield return new WaitForSeconds(Random.Range(3, 15));
        }
    }

    public void OnTwirl()
    {
        if (distanceX > 2f)
            animator.SetTrigger("TwirlRight");
        else if (distanceX < -2f)
            animator.SetTrigger("TwirlLeft");
    }

    public void OnFire()
    {
        animator.SetTrigger("Shoot");
    }
    
    void HandleRotation()
    {
        float desiredRotationX, desiredRotationZ = 0;

        Quaternion desiredRotation;

        if (distanceX > 2f)
        {
            desiredRotationZ = -15;
        }
        else if (distanceX < -2f)
        {
            desiredRotationZ = 15;
        }
        else
        {
            desiredRotationZ = 0;
        }

        if (distanceY > 2f)
        {
            desiredRotationX = -25;
        }
        else if (distanceY < -2f)
        {
            desiredRotationX = 25;
        }
        else
        {
            desiredRotationX = 0;
        }

        desiredRotation = Quaternion.Euler(desiredRotationX, 0, desiredRotationZ);
        playerMesh.transform.rotation = Quaternion.Lerp(playerMesh.transform.rotation, desiredRotation, Time.deltaTime * 5);

    }
}
