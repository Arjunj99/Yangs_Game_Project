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
    	acceleration = 15.81f;
        gravityDirection = -Vector3.up;
        newGravityDirection = gravityDirection;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Debug.Log(gravityDirection * acceleration);
        rb.AddForce(gravityDirection * acceleration);
    }

    void OnCollisionEnter(Collision gameObjectInformation)
    {
    	// acceleration = 15.81f;
    	// gravityDirection = newGravityDirection;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

