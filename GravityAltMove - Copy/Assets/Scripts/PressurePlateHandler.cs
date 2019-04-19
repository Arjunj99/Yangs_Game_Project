using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Attached to: Pressure plates
	Function: Detects collision, and when colliding with something, change
			  tag and material
*/
public class PressurePlateHandler : MonoBehaviour
{

	public Material deactivatedMaterial;
	public Material activatedMaterial;

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("colliding with something");
		GetComponent<Renderer>().material = activatedMaterial;

		tag = "NeutralizedDeactivator";
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log("Stopped colliding with something");
		tag = "Deactivator";
		GetComponent<Renderer>().material = deactivatedMaterial;
	}

}
