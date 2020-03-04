using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float distance = 400.0f;
    public Vector3 offsetFromTarget = new Vector3(1f, 1f, 1f);
    public Transform[] seatCameras;
    public Transform player;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private Transform target;

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;
   


    void Start()
    {
        SetCameraTarget(player);
    }


    public void SetCameraTarget(Transform t)
    {
        target = t;

        if (target == null)
        Debug.Log("Camera needs target");
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        Debug.Log(target.position);
        transform.position = target.position;
    }

    void LookAtTarget()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = target.position + (Quaternion.Euler(-currentY, currentX, 0) * new Vector3(0, 0, -distance));
            transform.LookAt(target.position);
        }else
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, target.up); 
        
    }
}
