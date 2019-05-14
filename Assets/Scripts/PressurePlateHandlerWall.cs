using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Attached to: Pressure plates
	Function: Detects collision, and when colliding with something, change
			  tag and material
*/
public class PressurePlateHandlerWall : MonoBehaviour
{

	public Material deactivatedMaterial;
	public Material activatedMaterial;
	public AudioSource plateSound;

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("Wall Pressure Plate Activated");
		GetComponent<Renderer>().material = activatedMaterial;
		if(tag != "WallNeutralizedDeactivator")
			plateSound.Play(0);

		tag = "WallNeutralizedDeactivator";
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log("Stopped colliding with something");
		tag = "WallDeactivator";
		GetComponent<Renderer>().material = deactivatedMaterial;
		Destroy(this.transform.gameObject);
	}

}
