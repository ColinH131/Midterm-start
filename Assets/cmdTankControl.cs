using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class cmdTankControl : MonoBehaviour
{
    public Rigidbody _Thisrigidbody;

    public Vector2 inputAxis;
    public float forceMultiplier = 1.5f;
    public float tankVelocity;
    public float inputToTorque;
    public float tankAccel;
    
    private bool isMoving;
    private bool keyHeld;
    private bool RotateHeld;
    
    private float Timeheld;
    
    void Start()
    {
        _Thisrigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x = Input.GetAxis("Horizontal");
        CheckKeys();
        inputToTorque = inputAxis.x;
        tankVelocity = _Thisrigidbody.velocity.magnitude;
        if (tankVelocity > 0)
        {
            isMoving = true;
            if (keyHeld)
            {
                forceMultiplier = forceMultiplier + (tankAccel * Time.deltaTime);
            }

        }
    }

    void FixedUpdate()
    {
        if (_Thisrigidbody.velocity.magnitude < 8f)
        {
            _Thisrigidbody.AddForce(transform.forward * inputAxis.y * forceMultiplier, ForceMode.Impulse);
        }
        _Thisrigidbody.AddTorque(0, inputToTorque, 0, ForceMode.VelocityChange);
    }

    void CheckKeys()
    {
        if (Input.GetKey(KeyCode.W))
        {
            keyHeld = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            keyHeld = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotateHeld = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateHeld = true;
        }
    }

}
