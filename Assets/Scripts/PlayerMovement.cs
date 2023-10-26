using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerHeight;
    public LayerMask whatIsGround;
    public float groundDrag;

    bool grounded;


    public float playerSpeed = 5f;

    public Transform orientation;

    public float horizontalInput;
    public float verticalInput;

    Rigidbody rb;
    public Vector3 direction;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // get horixontal and vertical input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //ground check 
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        // create a vector3 that moves the player
        direction = orientation.right * horizontalInput + orientation.forward * verticalInput;
        rb.AddForce(direction.normalized * playerSpeed * 10f, ForceMode.Force);
        //controller.Move(move * playerSpeed * Time.deltaTime);
    }

}
