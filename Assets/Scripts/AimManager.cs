using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AimManager : MonoBehaviour
{
    public Vector3 startPosition, finalPosition;
    Vector3 velocity = Vector3.zero;
    public bool expand;
    [Range (0.1f, 2f)] public float smoothTime = 1f;
    [SerializeField] SpriteRenderer aimRenderer;
    [FormerlySerializedAs("onTargetColor")] public Color targetColor;
    public Color offTargetColor;

    private void Start()
    {
        aimRenderer = GetComponent<SpriteRenderer>();
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
        aimRenderer.color = offTargetColor;

    }

    public void Compress()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, startPosition, ref velocity, smoothTime / 2);
        aimRenderer.color = targetColor;
    }
}
