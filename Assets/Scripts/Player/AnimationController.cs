using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public bool isPaused;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(RandomPlay());
    }

    IEnumerator RandomPlay()
    {
        while (!isPaused)
        {
            animator.SetTrigger("Fly");
            yield return new WaitForSeconds(Random.Range(3, 15));
        }
    }

    void Twirl()
    {
        animator.SetTrigger("Twirl");
    }

    public void OnFire()
    {
        animator.SetTrigger("Shoot");
    }
}
