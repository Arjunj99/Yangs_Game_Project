using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIsolationScript : MonoBehaviour
{

    public GameObject movableCube;

	Collider objectCollider;
	Renderer rend;

	void Start()
	{
	    objectCollider = GetComponent<Collider>();
	    rend = GetComponent<Renderer>();
	    //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
	}

	void Update()
    {
        if(GameObject.FindWithTag("WallNeutralizedDeactivator") != null)
        {
        	objectCollider.enabled = false;
        	rend.enabled = false;
        }

        else
        {
        	objectCollider.enabled = true;
        	rend.enabled = true;
        }

    }

 	private void OnTriggerEnter(Collider other)
    {
    	Debug.Log("Passing:" + other.name);
    	if(other.tag == "Moveable")
        {
            Instantiate(movableCube, new Vector3(5, 5, -35), Quaternion.identity);
    		Destroy(other.gameObject);
        }

    }
}
