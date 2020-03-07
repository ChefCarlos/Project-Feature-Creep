using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform seatControllerObject;
    public Transform player;

    private Transform target;

    /* postion
     * rotation
     * update of position + rotation
     * rescrict y angle max and min
     * how they are being controlled, mouse or keyboard
     * switch from camera to camera
     * position of camera compared to seat
    */

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

    }

    public Transform getPlayer
    {
        get { return player; }
        set { player = value; }
    }
}
