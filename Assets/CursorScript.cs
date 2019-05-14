using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update

	[SerializeField] private KeyCode restart;
	[SerializeField] private KeyCode hard;
	[SerializeField] private KeyCode exit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(restart))
        	SceneManager.LoadScene("Level 01");

        if(Input.GetKeyDown(hard))
        	SceneManager.LoadScene("Prep Room");

        if(Input.GetKeyDown(exit))
        	Application.Quit();


    }
}
