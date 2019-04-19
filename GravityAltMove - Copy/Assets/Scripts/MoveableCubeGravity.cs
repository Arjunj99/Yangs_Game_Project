using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Attached to: Moveable object
    Function: Handles gravity by constantly pulling the object in the direction
              of a pre-defined vector
*/
public class MoveableCubeGravity : MonoBehaviour
{
	public Vector3 newGravityDirection;
	public Vector3 gravityDirection;
	public float acceleration;
	Rigidbody rb;

    void Start()
    {
    	acceleration = 9.81f;
        gravityDirection = -Vector3.up;
        newGravityDirection = gravityDirection;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(gravityDirection * acceleration);
    }

    void OnCollisionEnter(Collision gameObjectInformation)
    {
    	acceleration = 9.81f;
    	gravityDirection = newGravityDirection;
    }
}

