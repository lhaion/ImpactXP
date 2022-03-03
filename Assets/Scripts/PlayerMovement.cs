using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private float smoothRotation;
    protected float speedCurrent { get; set; }
    private float h, v;
    public Transform mesh;
    private Rigidbody rb;

    //Position and movement variables
    public Transform aim;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Vector2 deltaAmplified, deltaPure;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Pure: " + deltaPure + " Amplified: " + deltaAmplified);
        aim.transform.Translate(deltaAmplified.x * Time.deltaTime, deltaAmplified.y * Time.deltaTime, 0);

        // Define a target position above and behind the target transform
        Vector3 aimPosition = aim.TransformPoint(aim.position);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }

    public void OnLook(InputValue value)
    {
        //print(value.isPressed);

        deltaAmplified = value.Get<Vector2>() * 10f;
        deltaPure = value.Get<Vector2>();

        aim.transform.Translate(deltaAmplified.x * Time.deltaTime, deltaAmplified.y * Time.deltaTime, 0);
    }
}
