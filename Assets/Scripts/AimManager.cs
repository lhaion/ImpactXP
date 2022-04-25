using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public Vector3 startPosition, finalPosition;
    Vector3 velocity = Vector3.zero;
    public bool expand;
    [Range (0.1f, 2f)] public float smoothTime = 1f;
    Renderer aimRenderer;

    private void Start()
    {
        aimRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (expand)
        {
            Expand();
        }
        else
        {
            Compress();
        }
    }

    public void Expand()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, finalPosition, ref velocity, smoothTime);
        aimRenderer.material.color = Color.white;

    }

    public void Compress()
    {
        transform.localPosition = startPosition;
        aimRenderer.material.color = Color.red;
    }
}
