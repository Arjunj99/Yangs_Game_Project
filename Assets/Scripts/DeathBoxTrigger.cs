using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxTrigger : MonoBehaviour
{

    // Start is called before the first frame update

	public Vector3 location;
	public GameObject movableCube;
    private bool cube_respawner = false;
    private string DMenu = "DeathMenu";

	void Start()
	{
		if(GameObject.FindWithTag("Moveable") != null)
			cube_respawner = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("falling through: " + other.name);
		if(other.tag == "Player")
		{
    		SceneManager.LoadScene(DMenu);
		}

    	else if (other.tag == "Moveable" && cube_respawner)
    	{
    		Instantiate(movableCube, location, Quaternion.identity);
    		Destroy(other);
    	}
	}
}
