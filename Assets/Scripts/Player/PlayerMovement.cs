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
    [Range (1, 10)][Min(1)]public float sense = 10f;
    


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

        // Smoothly move the player towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -8, 8), transform.position.z);

        float xDistance = transform.position.x - target.position.x;

        Debug.Log("Distance: " + xDistance);
    }

    public void OnLook(InputValue value)
    {
        //print(value.isPressed);

        deltaAmplified = value.Get<Vector2>() * sense;
        deltaPure = value.Get<Vector2>();

        aim.transform.Translate(deltaAmplified.x * Time.deltaTime, deltaAmplified.y * Time.deltaTime, 0);
    }
}
