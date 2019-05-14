using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWallCollider : MonoBehaviour
{

	public string SceneToTransitionTo = "DeathMenu";
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
    	Debug.Log("DEATHWALL" + other.name);
    	if(other.tag == "Player")
    		SceneManager.LoadScene(SceneToTransitionTo);
    }
}
