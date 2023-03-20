using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public float Sensitivity = 1000f;

    public Transform Player;
    public Joystick CameraJoystick;

    private float xRotate = 0f;

    void Update()
    {
        float mouseX = CameraJoystick.Horizontal * Sensitivity * Time.deltaTime;
        float mouseY = CameraJoystick.Vertical * Sensitivity * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);
    }
}
