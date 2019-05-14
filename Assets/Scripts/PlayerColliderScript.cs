using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColliderScript : MonoBehaviour
{
    // Start is called before the first frame update

	public string RespawnScene;

    private void OnTriggerEnter(Collider collider)
    {
    	//Debug.Log(collider.gameObject.name);
    	if(collider.gameObject.name == "Player")
    	{
    		Debug.Log("kill");
    		SceneManager.LoadScene(RespawnScene);
    	}

    }
}
