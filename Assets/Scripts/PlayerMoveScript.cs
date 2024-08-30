using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float movementSpeed = 10f; 
    public Transform cameraTransform; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;


        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();
        Vector3 direction = forward * vertical + right * horizontal;
        rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
    }
}
