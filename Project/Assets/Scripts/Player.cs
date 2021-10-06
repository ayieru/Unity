﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    float x, z;
    float speed;

    public GameObject cam;
    Quaternion cameraRot, playerRot;

    float xSensitivity = 3f, ySensitivity = 3f;

    bool cursorLock = true;

    float minX = -90f, maxX = 90f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        x = 0;
        z = 0;
        speed = 0.1f;

        cameraRot = cam.transform.localRotation;
        playerRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;
        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;

        transform.position += forward * z + cam.transform.right * x;

        float xRot = Input.GetAxis("Mouse X") * xSensitivity;
        float yRot = Input.GetAxis("Mouse Y") * ySensitivity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        playerRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = playerRot;

        UpdareCursorLock();
    }

    private void FixedUpdate()
    {
        

    }

    public void UpdareCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public Quaternion ClampRotation(Quaternion quat)
    {
        quat.x /= quat.w;
        quat.y /= quat.w;
        quat.z /= quat.w;
        quat.w = 1.0f;

        float angleX = Mathf.Atan(quat.x) * Mathf.Rad2Deg * 2.0f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        quat.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return quat;
    }

}
