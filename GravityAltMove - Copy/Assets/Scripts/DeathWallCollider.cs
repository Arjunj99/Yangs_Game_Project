using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWallCollider : MonoBehaviour
{

	public string SceneToTransitionTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
    	Debug.Log(other.name);
    	if(other.name == "Player")
    		SceneManager.LoadScene(SceneToTransitionTo);
    }
}
