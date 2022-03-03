using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private Transform desiredPosition;
    [SerializeField] private float speed = 10;
    private Animator animator;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        aim.transform.position = new Vector3 (0, 0, aim.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, desiredPosition.position, speed * Time.deltaTime);
        //aim.position = new Vector3(Mathf.Clamp(transform.position.x, -11.5f, 15.5f), Mathf.Clamp(transform.position.y, -6.3f, 15), transform.position.z);
        /*rb.MovePosition(Vector3.MoveTowards(transform.position, desiredPosition.position, speed * Time.deltaTime));*/
    }


    /*public void OnLook(InputValue value)
    {
        Vector2 delta = value.Get<Vector2>() * 30f;
        //Debug.Log(delta);

        if(delta.x != 0 || delta.y != 0)
        {
            aim.transform.Translate(delta.x * Time.deltaTime, delta.y * Time.deltaTime, 0);
            aim.transform.position = new Vector3(Mathf.Clamp(aim.transform.position.x, -11.5f, 15.5f), Mathf.Clamp(aim.transform.position.y, -6.3f, 15), aim.transform.position.z);
            transform.LookAt(aim.transform.position);
            animator.SetFloat("Yspeed", Mathf.Lerp(Mathf.Abs(delta.y) * 0.025f, 1, Time.deltaTime));
        }
    }*/
}
