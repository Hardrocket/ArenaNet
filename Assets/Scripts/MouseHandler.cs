using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    public float mouseSensitivity = 1f;
    private float _xRotation = 0.0f;
    private Camera _cam;
 
    void Start()
    {
        _cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
 
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
 
        _cam.transform.localRotation = Quaternion.Euler(_xRotation,0,0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
