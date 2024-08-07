using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Collider c;

    // freeze rotation x, y

    // constants
    private const float MoveForce = 500f; //250f; //500f
    private const float JumpForce = 150f; //250f
    private const float MouseSpeed = 1f; //0.5f; //1f
    private const float InitialRotationX = 0;

    private float mousePosY = 0f;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // jump!
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(0, JumpForce, 0);
            grounded = false;
        }


        // calculating horizontal camera control
        // vertical camera control located in camera script
        mousePosY += MouseSpeed * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(InitialRotationX, mousePosY, 0);

        // calculating movement vector
        // vertical is W, S
        // horizontal is A, D
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * MoveForce;
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * MoveForce;

        double rotationRadiansY = transform.eulerAngles.y * (Math.PI / 180);
        float rotationSin2H = (float)(Math.Sin(rotationRadiansY)/* * Math.Abs(Math.Sin(rotationRadiansY))*/);
        float rotationCos2H = (float)(Math.Cos(rotationRadiansY) /** Math.Abs(Math.Cos(rotationRadiansY))*/);
        float rotationSin2V = (float)(Math.Sin(Math.PI / 2 + rotationRadiansY) /* Math.Abs(Math.Sin(Math.PI / 2 + rotationRadiansY))*/);
        float rotationCos2V = (float)(Math.Cos(Math.PI / 2 + rotationRadiansY) /* Math.Abs(Math.Cos(Math.PI / 2 + rotationRadiansY))*/);

        Vector3 velocity = new Vector3(
            vertical * rotationSin2H + horizontal * rotationSin2V, /*left and right*/
            rb.velocity.y,
            vertical * rotationCos2H + horizontal * rotationCos2V /*forward and back*/
            );
        
        Debug.Log(velocity);

        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Terrain") || other.gameObject.name.Equals("Room") || other.gameObject.name.Equals("Plane"))
        {
            grounded = true;
        }
    }
}