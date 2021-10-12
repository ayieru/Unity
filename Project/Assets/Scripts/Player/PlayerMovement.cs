using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    Rigidbody rb;

    //移動速度関係
    Vector3 velocity;
    Vector3 accelation;
    [SerializeField] float walkSpeed;
    [SerializeField] float dashSpeedRate;
    [SerializeField] float jumpForce;
    int jumpState = 0;
    bool isGround = false;

    float groundDrag = 6f;
    float airDrag = 2f;

    public Vector3 localGravity;

    void MovementStart()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void MovementUpdate()
    {
        SetMove();
    }

    void MovementFixedUpdate()
    {
        SetLocalGravity();
    }

    private void SetMove()
    {
        float dashRate;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dashRate = dashSpeedRate;
        }
        else 
        {
            dashRate = 1;
        }

        if (rb.velocity.y < 0.01 && -0.01 < rb.velocity.y )
        {
            isGround = true;
        }
        else
        {
            isGround = false;
            Debug.Log(isGround);
        }

        float currentSpeed = walkSpeed * dashRate;
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        Vector3 up = transform.up; 
        forward.y = 0f;
        right.y = 0f;
        
        forward = Input.GetAxisRaw("Vertical") * forward * currentSpeed;
        right = Input.GetAxisRaw("Horizontal") * right * currentSpeed;

        //ControlDrag();
        Jump();
        velocity = forward + right;
        Debug.Log(rb.velocity);
        rb.AddForce(velocity.normalized, ForceMode.Impulse);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpState = 1;
            accelation.y = jumpForce;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        else
        {
            jumpState = 0;
        }
    }


    void ControlDrag()
    {
        if(isGround)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void SetLocalGravity()
    {
        rb.AddForce(localGravity, ForceMode.Acceleration);
    }

}
