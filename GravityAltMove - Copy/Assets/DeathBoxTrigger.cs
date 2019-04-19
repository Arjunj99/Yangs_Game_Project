using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxTrigger : MonoBehaviour
{

	public string SceneToTransitionTo;
    // Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("falling through: " + other.name);
		if(other.name == "Player")
    		SceneManager.LoadScene(SceneToTransitionTo);
	}
}
