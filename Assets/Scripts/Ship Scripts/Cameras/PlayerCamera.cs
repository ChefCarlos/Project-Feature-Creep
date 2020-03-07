using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraControllerTransform;

    public float mouseSensitivity = 10f;

    private float mouseX = 0f;
    private float mouseY = 0f;

    private float xRotation = 0f;

    private CameraController cameraController;
    private Transform player;

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;


    void Start()
    {
        cameraController = cameraControllerTransform.GetComponent<CameraController>();
        player = cameraController.getPlayer;
        transform.position = player.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        calculateMousePos();
        LookRotation();
    }

    void calculateMousePos()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void LateUpdate()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        //transform.position = player.position;
    }

    void LookRotation()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, Y_ANGLE_MIN, Y_ANGLE_MAX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
