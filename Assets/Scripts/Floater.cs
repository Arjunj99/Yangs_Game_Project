using UnityEngine;
using System.Collections;
 
public class Floater : MonoBehaviour{
 
/*
	Attached to: Rigid body gameobjects that need to float
	Function: Makes a rigid body game object float
*/

public float FloatStrenght;
      
     void Update () 
     {
     	transform.GetComponent<Rigidbody>().AddForce(Vector3.up *FloatStrenght);
     }
 
 }


//Courtesy: https://answers.unity.com/questions/518088/how-to-make-an-object-float-in-space.html