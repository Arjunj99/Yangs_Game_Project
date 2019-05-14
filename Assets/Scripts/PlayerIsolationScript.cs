using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerIsolationScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
    	Debug.Log("Passing:" + other.name);
    	if(other.tag == "Player")
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
