using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody playerBody;

    private float forwardInput, strafeInput = 0;

    public float moveSpeed = 12f;
    
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void getInput()
    {
        forwardInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        strafeInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        transform.Translate(strafeInput, 0f, forwardInput);
    }
}
