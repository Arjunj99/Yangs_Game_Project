using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Attached to: Exit doors
	Function: Deactivates exit door is an object with the tag "deactivator"
		  is found in the scene
*/

public class ColliderHandler : MonoBehaviour 
{
    Collider objectCollider;

    void Start()
    {
        objectCollider = GetComponent<Collider>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        if(GameObject.FindWithTag("Deactivator") != null)
        {
            objectCollider.enabled = false;
        }

        else
        {
        	objectCollider.enabled = true;
        }

    }
}
