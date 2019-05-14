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
	public AudioSource plateSound;

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("Pressure Plate Activated");
		GetComponent<Renderer>().material = activatedMaterial;
		if(tag != "NeutralizedDeactivator")
			plateSound.Play(0);

		tag = "NeutralizedDeactivator";
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log("Stopped colliding with something");
		tag = "Deactivator";
		GetComponent<Renderer>().material = deactivatedMaterial;
	}

}
