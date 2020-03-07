using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PilotController : MonoBehaviour
{
    public GameObject ship;

    public float accelerateSpeed = 1f;
    public float maxForwardSpeed = 60f;
    public float currentForwardSpeed = 0f;

    public float turnSpeed = .1f;
    public float maxTurnSpeed = 100f;
    public float currentYawSpeed = 0f;
    public float currentPitchSpeed = 0f;
    public float currentRotateSpeed = 0f;

  
    Rigidbody shipBody;
    private float forwardInput, turnInput, rotateInput, tiltInput = 0;

    void Start()
    {
        shipBody = ship.GetComponent<Rigidbody>();
    }

    void GetInputs()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        rotateInput = Input.GetAxis("Rotate");
        tiltInput = Input.GetAxis("Tilt");
    }


    void Update()
    {
        GetInputs();
        Rotate();
    }

    void FixedUpdate()
    {
        //Accelerate();
    }

    void Accelerate()
    {
        currentForwardSpeed = movementController(currentForwardSpeed, forwardInput, accelerateSpeed, maxForwardSpeed,10);

        shipBody.velocity = transform.forward * currentForwardSpeed;
    }

    void Rotate()
    {
        currentYawSpeed = movementController(currentYawSpeed, turnInput, turnSpeed, maxTurnSpeed,2);
        currentPitchSpeed = movementController(currentPitchSpeed, tiltInput, turnSpeed, maxTurnSpeed,2);
        currentRotateSpeed = movementController(currentRotateSpeed, rotateInput, turnSpeed, maxTurnSpeed,2);


        //float yaw = currentYawSpeed  * Time.deltaTime;
        //float pitch = currentPitchSpeed  * Time.deltaTime;
        float rotate = 10 * Time.deltaTime;
        //float rotate = currentRotateSpeed  * Time.deltaTime;

        //ship.transform.Rotate(-pitch, yaw, rotate);
        ship.transform.Rotate(0, 0, rotate);
    }

    private float movementController(float currMoveSpeed, float input, float moveRate, float maxMoveSpeed, float forwardOrTurningDigit)
    {
        if (currMoveSpeed < maxMoveSpeed && input > 0)
        {
            currMoveSpeed += moveRate * input;
            return currMoveSpeed;
        }
        else if (input == 0 && currMoveSpeed != 0)
        {
            currMoveSpeed = Mathf.SmoothStep(currMoveSpeed, 0, moveRate / forwardOrTurningDigit);
            return currMoveSpeed;
        }
        else if (currMoveSpeed > -maxMoveSpeed && input < 0)
        {
            currMoveSpeed += moveRate * input;
            return currMoveSpeed;
        }
        return currMoveSpeed;
    }


    
}
