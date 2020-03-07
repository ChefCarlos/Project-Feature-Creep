using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotCamera : MonoBehaviour
{
    public Transform cameraControllerTransform;

    private float offsetDistance = 100f;
    private float currentX = 0f;
    private float currentY = 0f;

    private CameraController cameraController;
    private Transform ship;

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    void Start()
    {
        cameraController = cameraControllerTransform.GetComponent<CameraController>();
        ship = cameraController.getPlayer;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        transform.position = ship.position;
    }

    void LookAtTarget()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = ship.position + (Quaternion.Euler(-currentY, currentX, 0) * new Vector3(0, 0, -offsetDistance));
            transform.LookAt(ship.position);
        }
        else
            transform.rotation = Quaternion.LookRotation(ship.position - transform.position, ship.up);

    }
}
