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
    public Game.ScriptableSettings settings;

    //Position and movement variables
    public Transform aim;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private Vector2 deltaAmplified, deltaPure;
    private Animator animator;
    [Range (1, 10)][Min(1)]public float sense;
    public float rotationSpeed = 180;

    public GameObject playerMesh;


    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        sense = settings.sense * 5;
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
        
        
    }

    private void FixedUpdate()
    {

    }

    

    public void OnLook(InputValue value)
    {
        deltaAmplified = value.Get<Vector2>() * (sense * 5);
        deltaPure = value.Get<Vector2>();

        aim.transform.Translate(deltaAmplified.x * Time.deltaTime, deltaAmplified.y * Time.deltaTime, 0);
    }

    public float CalcVelocity()
    {
        float xVelocity = transform.position.x - lastPosition.x;
        lastPosition = transform.position;

        return xVelocity * 10;
    }

}
