using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string SceneToTransitionTo;
/*
    Attached to:    Exit Doors
    Function:       Indicates which scene to transition to
*/
    void OnCollisionEnter(Collision gameObjectInformation)
    {
        //If the thing that collided with this object is the player
        //Transition to the given scene

        Debug.Log("General Collision Detected");
        Debug.Log(gameObjectInformation.gameObject.tag);

    	if(gameObjectInformation.gameObject.tag == "Player")
    	{
    		Debug.Log("Collision Detected");
            SceneManager.LoadScene(SceneToTransitionTo);
    	}
    }
}
