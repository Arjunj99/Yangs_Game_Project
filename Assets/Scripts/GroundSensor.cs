using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip playerLanding;
    public AudioClip objectThud;


    void OnCollisionEnter(Collision other)
    {
    	Debug.Log("Wall is colliding with " + other.gameObject.name);
    	GameObject Environment = GameObject.Find("Environment");
    	GroundSensorConsolidated gsc = Environment.GetComponent<GroundSensorConsolidated>();
    	if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(playerLanding);
    		gsc.playerTouchingGround = true;
        }

        else if(other.gameObject.tag == "Moveable")
        {
            audioSource.PlayOneShot(playerLanding);
        }
    }

    void OnCollisionExit(Collision other)
    {
    	Debug.Log("Wall is no longer colliding with " + other.gameObject.name);
    	GameObject Environment = GameObject.Find("Environment");
    	GroundSensorConsolidated gsc = Environment.GetComponent<GroundSensorConsolidated>();
    	if(other.gameObject.tag == "Player")
        {
    		gsc.playerTouchingGround = false;
        }
    }
}
