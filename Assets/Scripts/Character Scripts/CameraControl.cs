using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float MouseSpeed = 0.5f; //1f
    private float mousePosX = 0f;

    void Start()
    {

    }

    private void Update()
    {
        mousePosX -= MouseSpeed * Input.GetAxis("Mouse Y");
        Vector3 currentAngles = transform.eulerAngles;
        currentAngles.x = mousePosX;

        transform.eulerAngles = currentAngles;
    }
}