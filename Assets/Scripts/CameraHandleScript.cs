using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandleScript : MonoBehaviour
{
    public Transform player; 
    public float mouseSensitivity = 200f; 
    public float distanceFromPlayer = 5f; 

    private float pitch = 0f; // ”гол по вертикали
    private float yaw = 0f;   // ”гол по горизонтали

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // ќграничиваем вертикальный угол

        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = player.position + rotation * direction;
        transform.LookAt(player.position);
    }
}
