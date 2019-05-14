using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Attached to: Anything that requires a material change based on an enabled collider
    Function: Changes the material based on whether the collider is enabled or not
*/
public class MatChanger : MonoBehaviour
{

	public Material deactivatedMaterial;
	public Material activatedMaterial;
	Collider objectCollider; 
	bool last_state = false;


    void Start()
    {
         
    	objectCollider = GetComponent<Collider>();
    	last_state = objectCollider.enabled;

    	if(objectCollider.enabled == true)
    	{
    		last_state = objectCollider.enabled;
    		GetComponent<Renderer>().material = activatedMaterial;

    	}

    	else if(objectCollider.enabled == false)
    	{
    		last_state = objectCollider.enabled;
    		GetComponent<Renderer>().material = deactivatedMaterial;
    	}

    }


    void Update()
    {

    	if(objectCollider.enabled == true && objectCollider.enabled != last_state)
    	{
    		last_state = objectCollider.enabled;
    		GetComponent<Renderer>().material = activatedMaterial;

    	}

    	else if(objectCollider.enabled == false && objectCollider.enabled != last_state)
    	{
    		last_state = objectCollider.enabled;
    		GetComponent<Renderer>().material = deactivatedMaterial;
    	}



    }
}
