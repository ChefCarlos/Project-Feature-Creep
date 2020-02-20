using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{

    public float accelerateSpeed = 1f;
    public float maxForwardSpeed = 60f;
    public float currentForwardSpeed = 0f;

    public float turnSpeed = .1f;
    public float maxTurnSpeed = 100f;
    public float currentYawSpeed = 0f;
    public float currentPitchSpeed = 0f;
    public float currentRotateSpeed = 0f;

   

    Vector3 forwardVel;
    Rigidbody rbody;
    public float forwardInput, turnInput, rotateInput, tiltInput;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        forwardInput = turnInput = rotateInput = tiltInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        rotateInput = Input.GetAxis("Rotate");
        tiltInput = Input.GetAxis("Tilt");
    }


    void Update()
    {
        GetInput();
        Rotate();
    }

    void FixedUpdate()
    {
        Accelerate();
    }

    void Accelerate()
    {

        if (currentForwardSpeed < maxForwardSpeed && forwardInput > 0)
        {
            currentForwardSpeed += accelerateSpeed * forwardInput;
        }
        else if (forwardInput == 0 && currentForwardSpeed != 0)
        {
            currentForwardSpeed = Mathf.SmoothStep(currentForwardSpeed, 0, accelerateSpeed / 10);
        }
        else if (currentForwardSpeed > -maxForwardSpeed && forwardInput < 0)
        {
            currentForwardSpeed += accelerateSpeed * forwardInput;
        }

        rbody.velocity = transform.forward * currentForwardSpeed;
    }

    void Rotate()
    {
        //Turn Sideways   
        if (currentYawSpeed < maxTurnSpeed && turnInput > 0)
        {
            currentYawSpeed += turnSpeed * turnInput;
        }
        else if (turnInput == 0 && currentYawSpeed != 0)
        {
            currentYawSpeed = Mathf.SmoothStep(currentYawSpeed, 0, turnSpeed / 2);
        }
        else if (currentYawSpeed > -maxTurnSpeed && turnInput < 0)
        {
            currentYawSpeed += turnSpeed * turnInput;
        }
        //Tilt Forward/Back
        if (currentPitchSpeed < maxTurnSpeed && tiltInput > 0)
        {
            currentPitchSpeed += turnSpeed * tiltInput;
        }
        else if (tiltInput == 0 && currentPitchSpeed != 0)
        {
            currentPitchSpeed = Mathf.SmoothStep(currentPitchSpeed, 0, turnSpeed / 2);
        }
        else if (currentPitchSpeed > -maxTurnSpeed && tiltInput < 0)
        {
            currentPitchSpeed += turnSpeed * tiltInput;
        }
        //Rotate Sideways
        if (currentRotateSpeed < maxTurnSpeed && rotateInput > 0)
        {
            currentRotateSpeed += turnSpeed * rotateInput;
        }
        else if (rotateInput == 0 && currentRotateSpeed != 0)
        {
            currentRotateSpeed = Mathf.SmoothStep(currentRotateSpeed, 0, turnSpeed / 2);
        }
        else if (currentRotateSpeed > -maxTurnSpeed && rotateInput < 0)
        {
            currentRotateSpeed += turnSpeed * rotateInput;
        }


        float yaw = currentYawSpeed  * Time.deltaTime;
        float pitch = currentPitchSpeed  * Time.deltaTime;
        float rotate = currentRotateSpeed  * Time.deltaTime;

        transform.Rotate(-pitch, yaw, rotate);
    }


    
}
