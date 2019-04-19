using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{


    void OnCollisionEnter(Collision other)
    {
    	Debug.Log("Wall is colliding with " + other.gameObject.name);
    	GameObject Environment = GameObject.Find("Environment");
    	GroundSensorConsolidated gsc = Environment.GetComponent<GroundSensorConsolidated>();
    	if(other.gameObject.name == "Player")
    		gsc.playerTouchingGround = true;
    }

    void OnCollisionExit(Collision other)
    {
    	Debug.Log("Wall is no longer colliding with " + other.gameObject.name);
    	GameObject Environment = GameObject.Find("Environment");
    	GroundSensorConsolidated gsc = Environment.GetComponent<GroundSensorConsolidated>();
    	if(other.gameObject.name == "Player")
    		gsc.playerTouchingGround = false;
    }
}
